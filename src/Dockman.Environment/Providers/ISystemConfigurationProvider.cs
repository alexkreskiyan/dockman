namespace Dockman.Environment.Providers
{
    public interface ISystemConfigurationProvider
    {
        SystemConfiguration Load();
    }
}