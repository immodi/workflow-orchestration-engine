using WorkflowOrchestrationEngine.Application.Interfaces;

namespace WorkflowOrchestrationEngine.Infrastructure.Processors;

public abstract class Processor<TTask, TResult> : IProcessor<TTask, TResult>
    where TTask : ITask<TResult>
{
    public abstract Type TaskType { get; }
    public abstract Type ReturnType { get; }


    public abstract object Execute(ITask task);
    public abstract TResult Execute(TTask task);
    
    public bool CanHandle(Type taskType, Type returnType)
    {
        return taskType == TaskType && returnType == ReturnType;
    }

}