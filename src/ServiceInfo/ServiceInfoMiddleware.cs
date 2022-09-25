using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ServiceInfo;
internal class ServiceInfoMiddleware
{
    private const string ServiceNameKey = "service-name";
    private const string ServiceVersion = "service-version";

    private readonly IServiceInfoConfiguration _serviceInfo;
    private readonly RequestDelegate _next;

    internal ServiceInfoMiddleware(RequestDelegate next, IServiceInfoConfiguration serviceInfo)
    {
        _next = next;
        _serviceInfo = serviceInfo;
    }

    internal async Task InvokeAsync(HttpContext context)
    {
        string version =$"{_serviceInfo.ServiceVersion.major}_{_serviceInfo.ServiceVersion.minor}";
        context.Response.Headers.TryAdd(ServiceNameKey, _serviceInfo.ServiceName);
        context.Response.Headers.TryAdd(ServiceVersion, version);

        await _next.Invoke(context);
    }
}