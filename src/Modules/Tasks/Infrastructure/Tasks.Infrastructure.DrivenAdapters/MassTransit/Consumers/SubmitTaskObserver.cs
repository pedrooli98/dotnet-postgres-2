using MassTransit;
using Microsoft.Extensions.Logging;
using Tasks.Infrastructure.DrivenAdapters.MassTransit.Contracts;

namespace Tasks.Infrastructure.DrivenAdapters.MassTransit.Consumers;

public class SubmitTaskObserver(ILogger<SubmitTaskObserver> logger) : IConsumer<TaskSubmmited>
{
    public Task Consume(ConsumeContext<TaskSubmmited> context)
    {
        logger.LogInformation("Task with id {Id} was submitted", context.Message.UserId);
        return Task.CompletedTask;
    }
}
