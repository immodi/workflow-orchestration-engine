namespace WorkflowOrchestrationEngine.Application.Interfaces;

public interface ITaskProcessor<in TTask, out TResult>
    where TTask : ITask<TResult>
{
    TResult Execute(TTask task);
}