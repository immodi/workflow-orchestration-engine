using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Models;
using WorkflowOrchestrationEngine.Domain.Tasks.Addition;
using Task = WorkflowOrchestrationEngine.Domain.Models.Task;

namespace WorkflowOrchestrationEngine.Infrastructure.Processors;

public class AdditionTaskProcessor : ITaskProcessor<AdditionTask, AdditionResultBase>, ITaskProcessor
{
    public AdditionResultBase Execute(AdditionTask task)
    {
        return new AdditionResult(task.Input.Primary + task.Input.Secondary);
    }

    public Result Execute(Task task) 
    {
        return Execute((AdditionTask)task); 
    }
}