using Microsoft.AspNetCore.Mvc;
using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Models;
using WorkflowOrchestrationEngine.Domain.Tasks.Conditional;
using Task = WorkflowOrchestrationEngine.Domain.Models.Task;

namespace WorkflowOrchestrationEngine.Infrastructure.Processors;

public class ConditionalTaskProcessor([FromServices] NonGenericResolver resolver) 
    : ITaskProcessor<ConditionalTask, Result>, ITaskProcessor
{
    public Result Execute(ConditionalTask task)
    {
            var trueTaskProcessor = resolver.ResolveProcessor(task.Input.TrueTask);
            var falseTaskProcessor = resolver.ResolveProcessor(task.Input.FalseTask);
            
            if (trueTaskProcessor == null) 
                throw new NullReferenceException("Could not resolve true task processor");
            if (falseTaskProcessor == null) 
                throw new NullReferenceException("Could not resolve false task processor");
            
            return task.Input.Condition() 
                ? trueTaskProcessor.Execute(task.Input.TrueTask) 
                : falseTaskProcessor.Execute(task.Input.FalseTask);
    }

    public Result Execute(Task task)
    {
        return Execute((ConditionalTask)task);
    }

}
