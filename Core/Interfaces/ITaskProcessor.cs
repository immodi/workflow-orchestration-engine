using WorkflowOrchestrationEngine.Core.Models;
using Task = WorkflowOrchestrationEngine.Core.Models.Task;

namespace WorkflowOrchestrationEngine.Core.Interfaces;

public interface ITaskProcessor<in T, out TR> where T : Task where TR : Result
{
    TR Execute(T task);
}
