using Dockman.CLI.Commands;
using Dockman.CLI.Commands.Projects;
using Dockman.CLI.Platform;
using Dockman.Environment.Providers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dockman.CLI
{
    public class Program
    {
        public static int Main() => SecureRun().Result;

        private static async Task Run()
        {
            var commander = GetCommander();

            while (true)
            {
                Console.Write("> ");

                await commander.Run(GetCommand());
            }
        }

        private static Commander GetCommander()
        {
            var commander = new Commander();

            var shell = new ShellFactory(new SystemConfigurationProvider()).Create();

            commander.Register(new BuildProjectCommand(shell));

            return commander;
        }

        private static string GetCommand()
            => string.Join(" ", Console.ReadLine().Split(' ')
                .Select(arg => arg.Trim())
                .Where(arg => !string.IsNullOrWhiteSpace(arg)));

        private static async Task<int> SecureRun()
        {
            try
            {
                await Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return 1;
            }

            return 0;
        }
    }
}