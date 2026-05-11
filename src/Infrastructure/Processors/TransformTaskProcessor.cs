using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Models;
using WorkflowOrchestrationEngine.Domain.Tasks.Transform;

namespace WorkflowOrchestrationEngine.Infrastructure.Processors;

public class TransformTaskProcessor<TSourceResult, TOutputResult>
    : ITaskProcessor<
        TransformTask<TSourceResult, TOutputResult>,
        TOutputResult>
    where TSourceResult : Result
    where TOutputResult : Result
{
    public TOutputResult Execute(TransformTask<TSourceResult, TOutputResult> task)
    {
        return task.Input.TransformFunc(task.Input.SourceResult);
    }
}