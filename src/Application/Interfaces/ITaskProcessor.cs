using WorkflowOrchestrationEngine.Domain.Models;
using Task = WorkflowOrchestrationEngine.Domain.Models.Task;

namespace WorkflowOrchestrationEngine.Application.Interfaces;

public interface ITaskProcessor<in T, out TR> where T : Task where TR : Result
{
    TR Execute(T task);
}
