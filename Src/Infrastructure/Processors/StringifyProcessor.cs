using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Models.Tasks;

namespace WorkflowOrchestrationEngine.Infrastructure.Processors;


public abstract class StringifyProcessor : Processor<StringifyTask, string>
{
    public override Type TaskType { get; } = typeof (StringifyTask);
    public override Type ReturnType { get; } = typeof (string);
}

public sealed class StringifyProcessorImpl : StringifyProcessor
{
    public override object Execute(ITask task)
    {
        if (task is not StringifyTask stringifyTask)
            throw new ArgumentException(
                $"Expected {nameof(StringifyTask)}, got {task.GetType().Name}");

        return Execute(stringifyTask);        }

    public override string Execute(StringifyTask task)
    {
        return task.Value.ToString() ?? string.Empty;
    }
}