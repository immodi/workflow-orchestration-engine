using WorkflowOrchestrationEngine.Application.Interfaces;

namespace WorkflowOrchestrationEngine.Domain.Models.Tasks;

public sealed class AdditionTask(string id, params double[] numbers) : ITask<double>
{
    public string Id { get; } = id;

    public IReadOnlyList<double> Numbers { get; } = numbers;
}