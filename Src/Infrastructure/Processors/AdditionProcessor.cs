using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Models.Tasks;

namespace WorkflowOrchestrationEngine.Infrastructure.Processors;

public abstract class AdditionProcessor : Processor<AdditionTask, double>
{
    public override Type TaskType { get; } = typeof (AdditionTask);
    public override Type ReturnType { get; } = typeof (double);
}

internal sealed class AdditionProcessorImpl : AdditionProcessor
{
    public override object Execute(ITask task)
    {
        if (task is not AdditionTask additionTask)
            throw new ArgumentException(
                $"Expected {nameof(AdditionTask)}, got {task.GetType().Name}");

        return Execute(additionTask);
    }

    public override double Execute(AdditionTask task)
    {
        return task.Numbers.Sum();
    }
};