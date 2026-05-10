using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Tasks.Addition;

namespace WorkflowOrchestrationEngine.Infrastructure.Processors;

public class AdditionTaskProcessor : ITaskProcessor<AdditionTask, AdditionResult>
{
    public AdditionResult Execute(AdditionTask task)
    {
        return new AdditionResultImplementation(task.Input.Primary + task.Input.Secondary);
    }
}