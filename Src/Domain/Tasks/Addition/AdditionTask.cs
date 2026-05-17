using WorkflowOrchestrationEngine.Domain.Models;
using WorkflowOrchestrationEngine.Infrastructure.Processors;
using Task = WorkflowOrchestrationEngine.Domain.Models.Task;

namespace WorkflowOrchestrationEngine.Domain.Tasks.Addition;

public class AdditionTaskInput(int primary, int secondary)
{
    public readonly int Primary = primary;
    public readonly int Secondary = secondary;
}


public abstract class AdditionTaskBase(string id, AdditionTaskInput input): Task(id)
{
    public AdditionTaskInput Input { get; } = input;
}

public class AdditionTask(string id, AdditionTaskInput input): AdditionTaskBase(id, input);
