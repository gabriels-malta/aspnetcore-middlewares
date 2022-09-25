namespace ServiceInfo;

public interface IServiceInfo
{
    public string ServiceName { get; }
    public (int major, int minor) ServiceVersion { get; }
}
