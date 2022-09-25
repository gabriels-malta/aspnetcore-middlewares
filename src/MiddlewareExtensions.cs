using Microsoft.AspNetCore.Builder;

namespace HttpRequestCorrelation;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseCorrelation(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<CorrelationMiddleware>();
        return builder;
    }
}