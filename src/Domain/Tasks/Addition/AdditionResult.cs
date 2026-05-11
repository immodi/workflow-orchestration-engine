using WorkflowOrchestrationEngine.Domain.Models;

namespace WorkflowOrchestrationEngine.Domain.Tasks.Addition;

public abstract class AdditionResultBase(int output) : Result
{
    public int Output { get; } = output;
}

public class AdditionResult(int output) : AdditionResultBase(output);


