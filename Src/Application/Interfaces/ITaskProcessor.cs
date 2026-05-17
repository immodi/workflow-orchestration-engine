using WorkflowOrchestrationEngine.Domain.Models;
using WorkflowOrchestrationEngine.Domain.Tasks.Addition;
using Task = WorkflowOrchestrationEngine.Domain.Models.Task;

namespace WorkflowOrchestrationEngine.Application.Interfaces;

public interface ITaskProcessor<in T, out TR> where T : Task
{
    TR Execute(T task);
}

public interface ITaskProcessor
{
    Result Execute(Task task);
}