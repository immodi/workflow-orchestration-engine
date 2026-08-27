namespace WorkflowOrchestrationEngine.Application.Interfaces;

public interface ITask<TResult> 
{
    string Id { get; }
}