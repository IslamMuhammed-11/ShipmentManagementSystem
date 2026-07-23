using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ShipmentManagementSystem.Application.Behavior;

public class PerformanceBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{

    private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;
    const short LatencyMessuare = 500;

    public PerformanceBehavior(ILogger<PerformanceBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var response = await next();

        stopwatch.Stop();

        var ms = stopwatch.ElapsedMilliseconds;
        if (ms >= LatencyMessuare)
        {
            string responseName = typeof(TRequest).Name;
            _logger.LogWarning($"Request {responseName} took {ms} ms");
        }

        return response;
    }
}
