using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Models;
using WorkflowOrchestrationEngine.Domain.Tasks.Stringify;
using Task = WorkflowOrchestrationEngine.Domain.Models.Task;

namespace WorkflowOrchestrationEngine.Infrastructure.Processors;



public class StringifyTaskProcessor : ITaskProcessor<StringifyTask, StringifyResultBase>, ITaskProcessor
{
    public StringifyResultBase Execute(StringifyTask task)
    {
        var result = new StringifyResult($"{task.Input.Source}")
        {
            Success = true,
        };
        
        return result;
    }

    public Result Execute(Task task)
    {
        return Execute((StringifyTask)task);
    }
}