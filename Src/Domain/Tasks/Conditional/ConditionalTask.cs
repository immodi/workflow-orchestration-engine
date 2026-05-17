using Task = WorkflowOrchestrationEngine.Domain.Models.Task;

namespace WorkflowOrchestrationEngine.Domain.Tasks.Conditional;

public class ConditionalTaskInput(Task trueTask, Task falseTask, Func<bool> condition)
{
    public readonly Task TrueTask = trueTask;
    public readonly Task FalseTask = falseTask;
    public readonly Func<bool> Condition = condition;
}

public abstract class ConditionalTaskBase(string id, ConditionalTaskInput input): Task(id)
{
    public ConditionalTaskInput Input { get; } = input;
}

public class ConditionalTask(string id, ConditionalTaskInput input): ConditionalTaskBase(id, input);
