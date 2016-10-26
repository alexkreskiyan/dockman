using System;
using System.Runtime.InteropServices;

namespace Dockman.Environment.Providers
{
    public class SystemConfigurationProvider : ISystemConfigurationProvider
    {
        private static OSPlatform GetPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return OSPlatform.OSX;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return OSPlatform.Linux;

            return OSPlatform.Windows;
        }

        private static Lazy<OSPlatform> platform = new Lazy<OSPlatform>(GetPlatform, true);

        public SystemConfiguration Load()
        {
            var configuration = new SystemConfiguration();

            configuration.Platform = platform.Value;

            return configuration;
        }
    }
}