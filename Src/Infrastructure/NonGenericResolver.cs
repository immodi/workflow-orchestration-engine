using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc;
using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Tasks.Addition;
using WorkflowOrchestrationEngine.Domain.Tasks.Stringify;
using WorkflowOrchestrationEngine.Domain.Tasks.Transform;
using Task = WorkflowOrchestrationEngine.Domain.Models.Task;

namespace WorkflowOrchestrationEngine.Infrastructure;

public class NonGenericResolver([FromServices] IServiceProvider services)
{
    public ITaskProcessor ResolveProcessor(Task task) 
    {
        if (ResolveTransformProcessor(task) != null) return ResolveTransformProcessor(task)!;
        
        var processor = task switch
        {
            AdditionTask _ =>
                (ITaskProcessor)services.GetRequiredService<ITaskProcessor<AdditionTask, AdditionResultBase>>(),
            StringifyTask _ =>
                (ITaskProcessor)services.GetRequiredService<ITaskProcessor<StringifyTask, StringifyResultBase>>(),
            
            _ => throw new NotImplementedException()
        };
        
        return processor;
    }

    private ITaskProcessor? ResolveTransformProcessor(Task task)
    {
        var taskType = task.GetType();

        if (!taskType.IsGenericType ||
            taskType.GetGenericTypeDefinition() != typeof(TransformTask<,>)) return null;
        
        var genericArgs = taskType.GetGenericArguments();

        var outputType = genericArgs[1];

        var processorType = typeof(
                ITaskProcessor<,>)
            .MakeGenericType(taskType, outputType);

        return (ITaskProcessor)
            services.GetRequiredService(processorType);

    }
}