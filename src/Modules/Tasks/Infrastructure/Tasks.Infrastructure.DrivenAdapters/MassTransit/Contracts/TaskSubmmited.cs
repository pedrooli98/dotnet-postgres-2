namespace Tasks.Infrastructure.DrivenAdapters.MassTransit.Contracts;

public record TaskSubmmited
{
    public Guid UserId { get; init; }
}
