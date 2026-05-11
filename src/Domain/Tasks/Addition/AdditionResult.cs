using WorkflowOrchestrationEngine.Domain.Models;

namespace WorkflowOrchestrationEngine.Domain.Tasks.Addition;

public abstract class AdditionResult(int output) : Result
{
    public int Output { get; set; } = output;
}

public class AdditionResultImplementation(int output) : AdditionResult(output);
