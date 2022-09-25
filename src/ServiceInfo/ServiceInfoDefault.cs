using System;
using System.Reflection;

namespace ServiceInfo;

internal class ServiceInfoDefault : IServiceInfo
{
    public string ServiceName => Assembly.GetExecutingAssembly().GetName().Name ?? throw new ArgumentNullException(nameof(ServiceName));
    public (int major, int minor) ServiceVersion => (1, 0);
}
