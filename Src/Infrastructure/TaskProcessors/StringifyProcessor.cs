using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Models.Tasks;

namespace WorkflowOrchestrationEngine.Infrastructure.TaskProcessors;


public abstract class StringifyProcessor : ITaskProcessor<StringifyTask, string>
{
    public abstract string Execute(StringifyTask task);
}

public sealed class StringifyProcessorImpl : StringifyProcessor
{
    public override string Execute(StringifyTask task)
    {
        return task.Value.ToString() ?? string.Empty;
    }
}