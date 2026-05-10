namespace WorkflowOrchestrationEngine.Domain.Models;

public abstract class Result
{
    public bool Success { get; set; }

    public string? Error { get; set; }
    
    public DateTime DateTime { get; set; } = DateTime.Now;
}