using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Infrastructure.Processors;

namespace WorkflowOrchestrationEngine.Infrastructure;

public class ProcessorDispatcher : IProcessorDispatcher
{
    // ReSharper disable once StaticMemberInGenericType
    private static readonly List<IProcessor> Processors =
    [
        new AdditionProcessorImpl(),
        new StringifyProcessorImpl(),
        new ConditionalProcessorImpl(),
    ]; 
    public IProcessor GetProcessor(Type taskType, Type returnType)
    {
        return Processors.FirstOrDefault(
                   x => x.CanHandle(taskType, returnType))
               ?? throw new NotSupportedException(
                   $"No processor found for {taskType.Name} -> {returnType.Name}");
    }

    // public IProcessor<TTask, TResult> GetProcessor<TTask, TResult>()
    //     where TTask : ITask<TResult>
    // {
    //     return (IProcessor<TTask, TResult>)GetProcessor(
    //         typeof(TTask),
    //         typeof(TResult));
    // }
}