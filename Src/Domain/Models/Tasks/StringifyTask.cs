using WorkflowOrchestrationEngine.Application.Interfaces;

namespace WorkflowOrchestrationEngine.Domain.Models.Tasks;

public class StringifyTask (string id, object value) : ITask<string>
{
    public string Id { get; } = id;
    public object Value { get; } = value;
    
    public Type OutputType { get; } = typeof(string);
}
