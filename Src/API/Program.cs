using Microsoft.AspNetCore.Mvc;
using WorkflowOrchestrationEngine.Application.Extensions;
using WorkflowOrchestrationEngine.Application.Interfaces;
using WorkflowOrchestrationEngine.Domain.Models.Tasks;
using WorkflowOrchestrationEngine.Infrastructure;
using WorkflowOrchestrationEngine.Infrastructure.Processors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProcessors();

var app = builder.Build();

app.MapGet("/",
    () => Results.Ok(new {hello = "world!"}));

app.MapGet("/add", (
    IProcessorDispatcher processorDispatcher) =>
{
    var processor = processorDispatcher.GetProcessor(typeof(AdditionTask), typeof(double));
    var task = new AdditionTask("1", 10, 20, 30);
    var result = processor.Execute(task);

    return Results.Ok(result);
});

app.MapGet("/stringify", (
    IProcessorDispatcher processorDispatcher) =>
{
    var processor = processorDispatcher.GetProcessor(typeof(StringifyTask), typeof(string));
    
    var task = new StringifyTask("2", true);
    var result = processor.Execute(task);

    return Results.Ok(result);
});

app.MapGet("/conditional", (
    bool condition,
    IProcessorDispatcher processorDispatcher) =>
{
    var processor = processorDispatcher.GetProcessor(
        typeof(ConditionalTask),
        typeof(ITask));

    var additionTask = new AdditionTask("1", 10, 20, 30);
    var stringifyTask = new StringifyTask("2", true);

    var conditionalTask = new ConditionalTask(
        "3",
        additionTask,
        stringifyTask,
        () => condition);

    var task = processor.Execute(conditionalTask).Cast<ITask>();

    var p = processorDispatcher.GetProcessor(
        task.GetType(),
        task.OutputType);

    var result = p.Execute(task);

    return Results.Ok(result);
});

app.Run();