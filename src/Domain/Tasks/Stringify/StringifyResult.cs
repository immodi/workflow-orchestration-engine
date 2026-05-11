using WorkflowOrchestrationEngine.Domain.Models;

namespace WorkflowOrchestrationEngine.Domain.Tasks.Stringify;



public abstract class StringifyResultBase(string mes) : Result
{
    public string Message { get; set; } = mes;
}

public class StringifyResult(string mes) : StringifyResultBase(mes);


