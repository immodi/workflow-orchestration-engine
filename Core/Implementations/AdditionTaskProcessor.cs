using WorkflowOrchestrationEngine.Core.Interfaces;
using WorkflowOrchestrationEngine.Core.Models.SubModels;

namespace WorkflowOrchestrationEngine.Core.Implementations;

public class AdditionTaskProcessor : ITaskProcessor<AdditionTask, AdditionResult>
{
    public AdditionResult Execute(AdditionTask task)
    {
        return new AdditionResult(task.Primary + task.Secondary);
    }
}