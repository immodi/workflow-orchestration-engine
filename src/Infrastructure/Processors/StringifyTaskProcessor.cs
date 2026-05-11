using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Tasks.Stringify;

namespace WorkflowOrchestrationEngine.Infrastructure.Processors;



public class StringifyTaskProcessor : ITaskProcessor<StringifyTask, StringifyResultBase>
{
    public StringifyResultBase Execute(StringifyTask task)
    {
        var result = new StringifyResult($"{task.Input}")
        {
            Success = true
        };
        
        return result;
    }
}