namespace WorkflowOrchestrationEngine.Application.Interfaces;

public interface IProcessor
{
    Type TaskType { get; }
    Type ReturnType { get; }
    bool CanHandle(Type taskType, Type returnType);
    object Execute(ITask task);
}

public interface IProcessor<in TTask, out TResult> : IProcessor
    where TTask : ITask<TResult>
{
    TResult Execute(TTask task);
}
