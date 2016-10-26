using Dockman.Environment.Providers;
using System.Runtime.InteropServices;

namespace Dockman.CLI.Platform
{
    public class ShellFactory
    {
        private readonly ISystemConfigurationProvider systemConfigurationProvider;

        public ShellFactory(ISystemConfigurationProvider systemConfigurationProvider)
        {
            this.systemConfigurationProvider = systemConfigurationProvider;
        }

        public IShell Create()
        {
            var platform = this.systemConfigurationProvider.Load().Platform;

            if (platform == OSPlatform.Windows)
                return new WinShell();

            return new NixShell();
        }
    }
}