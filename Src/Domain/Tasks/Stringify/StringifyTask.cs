using Task = WorkflowOrchestrationEngine.Domain.Models.Task;

namespace WorkflowOrchestrationEngine.Domain.Tasks.Stringify;


public class StringifyTaskInput(object source)
{
    public object Source { get; } = source;
}


public abstract class StringifyTaskBase(string id, StringifyTaskInput input): Task(id)
{
    public StringifyTaskInput Input { get; } = input;
}

public class StringifyTask(string id, StringifyTaskInput input): StringifyTaskBase(id, input);
