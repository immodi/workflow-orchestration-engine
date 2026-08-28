using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Infrastructure.Processors;

namespace WorkflowOrchestrationEngine.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProcessors(this IServiceCollection services)
    {
        services.AddScoped<IProcessorDispatcher, ProcessorDispatcher>();        
        
        return services;
    }

}