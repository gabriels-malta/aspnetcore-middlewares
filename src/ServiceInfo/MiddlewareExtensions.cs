
using System;
using Microsoft.AspNetCore.Builder;

namespace ServiceInfo
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseServiceInfo(this IApplicationBuilder builder, Action<IServiceInfoConfiguration>? options = null)
        {
            var defaultOptions = new ServiceInfoDefault();
            options?.Invoke(defaultOptions);
            return builder.UseMiddleware<ServiceInfoMiddleware>(defaultOptions);
        }
    }
}