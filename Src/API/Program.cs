using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Models;
using WorkflowOrchestrationEngine.Domain.Tasks.Addition;
using WorkflowOrchestrationEngine.Domain.Tasks.Conditional;
using WorkflowOrchestrationEngine.Domain.Tasks.Stringify;
using WorkflowOrchestrationEngine.Domain.Tasks.Transform;
using WorkflowOrchestrationEngine.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAllProcessors();

var app = builder.Build();

app.MapGet("/add",
    ([FromServices] ITaskProcessor<AdditionTask, AdditionResultBase> processor) =>
    {
        var task = new AdditionTask(
            "1",
            new AdditionTaskInput(1, 2)
        );

        var result = processor.Execute(task);

        return Results.Ok(result.Output);
    });


app.MapGet("/transform",
    ([FromServices]
        ITaskProcessor<
            TransformTask<AdditionResult, StringifyResult>, StringifyResult> processor) =>
    {
        
        var sourceResult = new AdditionResult(3+21);
        var transformTask =
            new TransformTask<AdditionResult, StringifyResult>(
                "2",
                new TransformTaskInput<AdditionResult, StringifyResult>(
                    sourceResult, 
                    additionResult => new StringifyResult(additionResult.Output.ToString())
                )
            );
        
        var result = processor.Execute(transformTask);
        return Results.Ok(result.Output);
    });
 
app.MapGet("/conditional", (
    [FromServices] ITaskProcessor<ConditionalTask, Result> processor,
    [FromServices] ITaskProcessor<TransformTask<Result, StringifyResult>, StringifyResult> transformProcessor) =>
{
    var trueTask = new AdditionTask("1", new AdditionTaskInput(1, 22));
    var falseTask = new StringifyTask("2", new StringifyTaskInput(999));

    var conditionalTask = new ConditionalTask(
        "3",
        new ConditionalTaskInput(trueTask, falseTask, () => true));

    var genericResult = processor.Execute(conditionalTask);

    var transformTask =
        new TransformTask<Result, StringifyResult>(
            "4",
            new TransformTaskInput<Result, StringifyResult>(
                genericResult,
                transformResult => transformResult switch
                {
                    AdditionResult addition =>
                        new StringifyResult(addition.Output?.ToString() ?? string.Empty),

                    StringifyResult stringify =>
                        new StringifyResult(stringify.Output?.ToString() ?? string.Empty),

                    _ => throw new InvalidOperationException(
                        $"Unsupported result type: {transformResult.GetType().Name}")
                }
            )
        );

    var result = transformProcessor.Execute(transformTask);

    return Results.Ok(result.Output);
});
app.Run();