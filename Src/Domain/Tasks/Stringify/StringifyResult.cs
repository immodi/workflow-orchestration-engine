using WorkflowOrchestrationEngine.Domain.Models;

namespace WorkflowOrchestrationEngine.Domain.Tasks.Stringify;

public abstract class StringifyResultBase : Result
{
    protected StringifyResultBase(string mes)
    {
        Output = mes;
    }
}

public class StringifyResult(string mes) : StringifyResultBase(mes);


