namespace WorkflowOrchestrationEngine.Application.Extensions;

public static class ObjectExtensions
{
    public static T Cast<T>(this object value)
    {
        return (T)value;
    }
}