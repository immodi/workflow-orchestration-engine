using WorkflowOrchestrationEngine.Application.Interfaces;

namespace WorkflowOrchestrationEngine.Domain.Models.Tasks;

public class ConditionalTask(string id, ITask trueTask, ITask falseTask, Func<bool> callback) : ITask<ITask>
{
    public string Id { get; } = id;
    public Func<bool> Callback { get; } = callback;
    public Type OutputType { get; } = typeof(ITask);
    public ITask FinalTask { get; set; } = null!; 
    public ITask TrueTask { get; } = trueTask;
    public ITask FalseTask { get; } = falseTask;
}