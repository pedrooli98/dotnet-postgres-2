# Event Bus POC

## 1. Overview

For demonstration sake, this project looks to demo the integration of an Event Bus, using the package MassTransit, to a simple .NET service using the Hexagonal Architecutre approach that is used in the main project;

## 2. Objectives

- Posting messages to an Event Bus queue using the Consumer pattern in MassTransit;
- Using the request/response pattern in MassTransit to orchestrate more complex events in a Modular Monolith context;

## 3. Demo

### 3.1 MassTransit concepts

#### Messages

In MassTransit, a message contract is defined code first by creating a .NET type. A message can be defined using a record, class, or interface. Messages should only consist of properties, methods and other behavior should not be included. It resembles the models or DTO classes that we are using;

##### IMPLEMENTATION(messages)

In the Task Service, everytime we want to post a new item an id is expected in this POST request, wich should correspond to an User, this message should look like this:

```csharp
public record TaskSubmmited
{
    public Guid UserId { get; init; }
}
```

In this use case we want to send a simple message with the userId stored;

#### Consumers

Consumer is a widely used noun for something that consumes something. In MassTransit, a consumer consumes one or more message types when configured on or connected to a receive endpoint.

##### IMPLEMENTATION(consumers)

```csharp
public class SubmitTaskObserver(ILogger<SubmitTaskObserver> logger) : IConsumer<TaskSubmmited>
{
    public Task Consume(ConsumeContext<TaskSubmmited> context)
    {
        logger.LogInformation("Task with id {Id} was submitted", context.Message.UserId);
        return Task.CompletedTask;
    }
}
```

#### Producers

An application or service can produce messages using two different methods. A message can be sent or a message can be published. The behavior of each method is very different, but it's easy to understand by looking at the type of messages involved with each particular method.

##### IMPLEMENTATION(producers)

In our case the producers a publish type, will live in our Controllers/Rest Adapters:

```csharp
[HttpPost]
[Route("")]
[ProducesResponseType(StatusCodes.Status201Created)]
public async Task<IActionResult> Create([FromBody] Todo task, [FromServices] ICreateTask createTask, [FromServices] IPublishEndpoint publishEndpoint)
{
    var createdTask = await createTask.Execute(task);
    await publishEndpoint.Publish<TaskSubmmited>(new() { UserId = createdTask.Id });
    return CreatedAtAction(nameof(Get), new { id = createdTask.Id }, createdTask);
}
```

