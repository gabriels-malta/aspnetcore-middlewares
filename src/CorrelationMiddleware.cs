using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace HttpRequestCorrelation;
internal class CorrelationMiddleware
{
    private const string CorrelationIdKey = "correlation-id";
    private const string CorrelationCreated = "CREATED";
    private const string CorrelationForwarded = "FORWARDED";
    private readonly string CorrelationLogMessagePattern = "CorrelationId: {correlationId} - {action}";
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    internal CorrelationMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger("HttpRequestCorrelation");
    }

    internal async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(CorrelationIdKey, out var correlationId))
        {
            correlationId = Guid.NewGuid().ToString("N");
            _logger.LogInformation(CorrelationLogMessagePattern, correlationId, CorrelationCreated);
            context.Request.Headers.Add(CorrelationIdKey, correlationId);
        }
        else
            _logger.LogInformation(CorrelationLogMessagePattern, correlationId, CorrelationForwarded);

        await _next.Invoke(context);
    }
}
