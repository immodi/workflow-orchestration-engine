using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Models;
using WorkflowOrchestrationEngine.Domain.Tasks.Transform;
using Task = WorkflowOrchestrationEngine.Domain.Models.Task;

namespace WorkflowOrchestrationEngine.Infrastructure.Processors;

public class TransformTaskProcessor<TSourceResult, TOutputResult>
    : ITaskProcessor<
        TransformTask<TSourceResult, TOutputResult>,
        TOutputResult>, ITaskProcessor
    where TSourceResult : Result
    where TOutputResult : Result
{
    public TOutputResult Execute(TransformTask<TSourceResult, TOutputResult> task)
    {
        return task.Input.TransformFunc(task.Input.SourceResult);
    }

    public Result Execute(Task task)
    {
        return Execute((TransformTask<TSourceResult, TOutputResult>)task);
    }
}