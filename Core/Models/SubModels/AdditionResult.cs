namespace WorkflowOrchestrationEngine.Core.Models.SubModels;

public class AdditionResult(int output) : Result
{
    public int Output { get; set; } = output;
}