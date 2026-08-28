namespace WorkflowOrchestrationEngine.Application.Interfaces;

public interface ITask
{
    string Id { get; }
    Type OutputType { get; }
}

public interface ITask<out TResult> : ITask;