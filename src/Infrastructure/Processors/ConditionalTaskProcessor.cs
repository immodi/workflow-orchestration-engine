// using WorkflowOrchestrationEngine.Application.Interfaces;
// using WorkflowOrchestrationEngine.Domain.Tasks.Conditional;
//
// namespace WorkflowOrchestrationEngine.Infrastructure.Processors;
//
// public class ConditionalTaskProcessor : ITaskProcessor<ConditionalTask, ConditionalResultBase>
// {
//     public ConditionalResultBase Execute(ConditionalTask task)
//     {
//         if (task.Input.Condition())
//         {
//             return new ConditionResult(task.Input.TrueTask);
//         }
//     }
// }
