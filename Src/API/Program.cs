using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Models.Tasks;
using WorkflowOrchestrationEngine.Infrastructure;
using WorkflowOrchestrationEngine.Infrastructure.TaskProcessors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProcessors();

var app = builder.Build();

app.MapGet("/",
    () => Results.Ok(new {hello = "world!"}));

app.MapGet("/add", (
    AdditionProcessor processor) =>
{
    var task = new AdditionTask("1", 10, 20, 30);

    var result = processor.Execute(task);

    return Results.Ok(result);
});

app.MapGet("/stringify", (
    StringifyProcessor processor) =>
{
    var task1 = new StringifyTask("1", false);
    var task2 = new StringifyTask("2", 22);
    var task3 = new StringifyTask("3", "hello");

    var result1 = processor.Execute(task1);
    var result2 = processor.Execute(task2);
    var result3 = processor.Execute(task3);

    return Results.Ok(new
    {
        resultOne = result1,
        resultTwo = result2,
        resultThree = result3
    });
});

app.Run();