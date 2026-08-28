namespace WorkflowOrchestrationEngine.Application.Interfaces;

public interface IProcessorDispatcher
{
    
    public IProcessor GetProcessor(Type taskType, Type returnType);
    // public IProcessor<TTask, TResult> GetProcessor<TTask, TResult>() where TTask : ITask<TResult>;
}