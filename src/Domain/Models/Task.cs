namespace WorkflowOrchestrationEngine.Domain.Models;

public abstract class Task(string id)
{
    public string Id { get; set; } = id;
    // public abstract Result Execute();
}