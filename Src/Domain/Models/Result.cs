namespace WorkflowOrchestrationEngine.Domain.Models;

public abstract class Result
{
    public bool Success { get; set; }

    public object? Output { get; protected init; }
    public string? Error { get; set; }
    
    public DateTime DateTime { get; set; } = DateTime.Now;
}