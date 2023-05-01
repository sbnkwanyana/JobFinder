using System.Diagnostics;
using MediatR;

namespace JobFinder.JobListings;

/* public class AddJobListingBehavior : IPipelineBehavior<AddJobListingCommand, Unit>
{
    public readonly ILogger<AddJobListingBehavior> _logger;

    public AddJobListingBehavior(ILogger<AddJobListingBehavior> logger)
    {
        _logger = logger;
    }

    public async Task<Unit> Handle(AddJobListingCommand request, RequestHandlerDelegate<Unit> next, CancellationToken cancellationToken)
    {
        var start = Stopwatch.GetTimestamp();
        var result = await next();
        var delta = Stopwatch.GetElapsedTime(start);
        _logger.LogInformation($"AddJobListingCommand took {delta}");
        return result;
    }
} */

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    public readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var start = Stopwatch.GetTimestamp();
        var result = await next();
        var delta = Stopwatch.GetElapsedTime(start);
        _logger.LogInformation($"Request {typeof(TRequest).Name} took {delta}");
        return result;
    }
}