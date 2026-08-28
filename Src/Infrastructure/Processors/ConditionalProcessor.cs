using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Models.Tasks;

namespace WorkflowOrchestrationEngine.Infrastructure.Processors;

public abstract class ConditionalProcessor : Processor<ConditionalTask, ITask>
{
    public override Type TaskType { get; }  = typeof (ConditionalTask);
    public override Type ReturnType { get; } = typeof (ITask);
}

public sealed class ConditionalProcessorImpl : ConditionalProcessor
{
    public override object Execute(ITask task)
    {
        if (task is not ConditionalTask conditionalTask)
            throw new ArgumentException(
                $"Expected {nameof(ConditionalTask)}, got {task.GetType().Name}");

        return Execute(conditionalTask);        
    }

    public override ITask Execute(ConditionalTask task)
    {
        task.FinalTask = task.Callback() ? task.TrueTask : task.FalseTask;
        
        return task.FinalTask;
    }
};