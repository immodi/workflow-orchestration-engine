using Microsoft.AspNetCore.Mvc;
using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Tasks.Addition;
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
            TransformTask<AdditionResult, StringifyResult>,
            StringifyResultBase> processor) =>
    {
        
        var sourceResult = new AdditionResult(3+21);
        var transformTask =
            new TransformTask<AdditionResult, StringifyResult>(
                "2",
                new TransformTaskInput<
                    AdditionResult,
                    StringifyResult>(sourceResult, TransformFunc)
            );


        var result = processor.Execute(transformTask);

        return Results.Ok(result.Message);

        StringifyResult TransformFunc(AdditionResult source)
        {
            return new StringifyResult(source.Output.ToString());
        }
    });
    
app.Run();