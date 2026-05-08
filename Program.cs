using WorkflowOrchestrationEngine.Core.Implementations;
using WorkflowOrchestrationEngine.Core.Models.SubModels;


var task = new AdditionTask
{
    Primary = 2,
    Secondary = 4,
    Id = "id"
};


var processor = new AdditionTaskProcessor();

Console.WriteLine(processor.Execute(task).Output);