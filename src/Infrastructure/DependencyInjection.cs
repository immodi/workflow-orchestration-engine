using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Tasks.Addition;
using WorkflowOrchestrationEngine.Domain.Tasks.Stringify;
using WorkflowOrchestrationEngine.Domain.Tasks.Transform;
using WorkflowOrchestrationEngine.Infrastructure.Processors;

namespace WorkflowOrchestrationEngine.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllProcessors(this IServiceCollection services)
    {
        services.AddAdditionProcessor();
        services.AddTransformProcessor_AdditionToStringify();
        
        return services;
    }

    private static IServiceCollection AddAdditionProcessor(this IServiceCollection services)
    {
        services.AddScoped<ITaskProcessor<AdditionTask, AdditionResultBase>, AdditionTaskProcessor>();
        return services;
    }

    private static IServiceCollection AddTransformProcessor_AdditionToStringify(this IServiceCollection services)
    {
        services.AddTaskProcessor<AdditionResult, StringifyResult>();
        return services;
    }

    private static IServiceCollection AddTaskProcessor<T, TR>(this IServiceCollection services)
        where T : AdditionResultBase
        where TR : StringifyResultBase
    {
        services.AddScoped<
            ITaskProcessor<TransformTask<T, TR>, StringifyResultBase>,
            TransformTaskProcessor<T, TR>>();
        return services;
    }
}