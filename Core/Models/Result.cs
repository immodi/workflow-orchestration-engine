namespace WorkflowOrchestrationEngine.Core.Models;

public abstract class Result
{
    public bool Success { get; set; }

    public string? Error { get; set; }
}