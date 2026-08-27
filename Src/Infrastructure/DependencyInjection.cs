using WorkflowOrchestrationEngine.Infrastructure.TaskProcessors;

namespace WorkflowOrchestrationEngine.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProcessors(this IServiceCollection services)
    {
        services.AddScoped<AdditionProcessor, AdditionProcessorImpl>(); 
        services.AddScoped<StringifyProcessor, StringifyProcessorImpl>(); 
        
        return services;
    }

}