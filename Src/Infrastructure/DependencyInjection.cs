using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Models;
using WorkflowOrchestrationEngine.Domain.Tasks.Addition;
using WorkflowOrchestrationEngine.Domain.Tasks.Conditional;
using WorkflowOrchestrationEngine.Domain.Tasks.Stringify;
using WorkflowOrchestrationEngine.Domain.Tasks.Transform;
using WorkflowOrchestrationEngine.Infrastructure.Processors;

namespace WorkflowOrchestrationEngine.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllProcessors(this IServiceCollection services)
    {
        services.AddProcessors();
        services.AddTransformProcessor_AdditionToStringify();
        services.AddNonGenericResolver();
        
        return services;
    }
    
    private static IServiceCollection AddNonGenericResolver(this IServiceCollection services)
    {
        services.AddScoped<NonGenericResolver>();
        
        return services;
    }

    private static IServiceCollection AddProcessors(this IServiceCollection services)
    {
        services.AddScoped<ITaskProcessor<AdditionTask, AdditionResultBase>, AdditionTaskProcessor>();
        services.AddScoped<ITaskProcessor<StringifyTask, StringifyResultBase>, StringifyTaskProcessor>();
        services.AddScoped<ITaskProcessor<ConditionalTask, Result>, ConditionalTaskProcessor>();
        
        return services;
    }

    private static IServiceCollection AddTransformProcessor_AdditionToStringify(
        this IServiceCollection services)
    {
        services.AddTransformTaskProcessor<AdditionResult, StringifyResult>();
        services.AddTransformTaskProcessor<Result, StringifyResult>();

        return services;
    }

    private static IServiceCollection AddTransformTaskProcessor<TSource, TOutput>(
        this IServiceCollection services)
        where TSource : Result
        where TOutput : Result
    {
        services.AddScoped<
            ITaskProcessor<TransformTask<TSource, TOutput>, TOutput>,
            TransformTaskProcessor<TSource, TOutput>>();

        return services;
    }
}