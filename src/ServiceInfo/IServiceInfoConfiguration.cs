namespace ServiceInfo;

public interface IServiceInfoConfiguration
{
    public string ServiceName { get; }
    public (int major, int minor) ServiceVersion { get; }
}
