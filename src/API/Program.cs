using Microsoft.AspNetCore.Mvc;
using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Tasks.Addition;
using WorkflowOrchestrationEngine.Infrastructure.Processors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITaskProcessor<AdditionTask, AdditionResult>, AdditionTaskProcessor>();

var app = builder.Build();

app.MapGet("/", ([FromServices] ITaskProcessor<AdditionTask, AdditionResult> processor) =>
{
    var task = new AdditionTask(
        "1",
        new AdditionTaskInput(1, 2)
    );

    var result = processor.Execute(task);

    return Results.Ok(result.Output);
});

app.Run();