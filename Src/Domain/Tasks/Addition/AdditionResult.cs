using WorkflowOrchestrationEngine.Domain.Models;

namespace WorkflowOrchestrationEngine.Domain.Tasks.Addition;

public abstract class AdditionResultBase : Result
{
    protected AdditionResultBase(int output)
    {
        Output = output;
    }
}

public class AdditionResult(int output) : AdditionResultBase(output);


