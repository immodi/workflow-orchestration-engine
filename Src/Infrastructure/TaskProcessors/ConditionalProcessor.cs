// using WorkflowOrchestrationEngine.Application.Interfaces;
// using WorkflowOrchestrationEngine.Domain.Models.Tasks;
//
// namespace WorkflowOrchestrationEngine.Infrastructure.TaskProcessors;
//
//
//
// public abstract class ConditionalProcessor : ITaskProcessor<ConditionalTask, double>
// {
//     public abstract double Execute(AdditionTask task);
// }
//
// public sealed class ConditionalProcessorImpl : AdditionProcessor
// {
//     public override double Execute(AdditionTask task)
//     {
//         return task.Numbers.Sum();
//     }
// };