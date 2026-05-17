using WorkflowOrchestrationEngine.Domain.Models;
using Task = WorkflowOrchestrationEngine.Domain.Models.Task;

namespace WorkflowOrchestrationEngine.Domain.Tasks.Transform;

public class TransformTaskInput<TSourceResult, TOutputResult>(
    TSourceResult sourceResult,
    Func<TSourceResult, TOutputResult> transformFunc)
{
    public TSourceResult SourceResult { get; } = sourceResult;
    public Func<TSourceResult, TOutputResult> TransformFunc { get; } = transformFunc;
}


public class TransformTask<TSourceResult, TOutputResult>(
        string id,
        TransformTaskInput<TSourceResult, TOutputResult> input
        ) : Task(id)
    where TSourceResult : Result
    where TOutputResult : Result
{
    public TransformTaskInput<TSourceResult, TOutputResult> Input { get; } = input;
}

