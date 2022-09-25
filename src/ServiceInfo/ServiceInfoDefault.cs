using System;
using System.Reflection;

namespace ServiceInfo;

internal class ServiceInfoDefault : IServiceInfoConfiguration
{
    public string ServiceName => Assembly.GetExecutingAssembly().GetName().Name ?? throw new ArgumentNullException(nameof(ServiceName));
    public (int major, int minor) ServiceVersion => (1, 0);
}
