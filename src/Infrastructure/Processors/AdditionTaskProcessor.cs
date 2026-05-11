using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Tasks.Addition;

namespace WorkflowOrchestrationEngine.Infrastructure.Processors;

public class AdditionTaskProcessor : ITaskProcessor<AdditionTask, AdditionResultBase>
{
    public AdditionResultBase Execute(AdditionTask task)
    {
        return new AdditionResult(task.Input.Primary + task.Input.Secondary);
    }
}