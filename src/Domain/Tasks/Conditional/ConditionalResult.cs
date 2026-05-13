using WorkflowOrchestrationEngine.Domain.Models;

namespace WorkflowOrchestrationEngine.Domain.Tasks.Conditional;

public abstract class ConditionalResultBase(Result trueTaskResult) : Result
{
    public Result TaskResult { get; } = trueTaskResult;
}

public class ConditionResult(Result trueTaskResult) : ConditionalResultBase(trueTaskResult);


