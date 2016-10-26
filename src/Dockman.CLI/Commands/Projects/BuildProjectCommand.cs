using Dockman.CLI.Platform;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dockman.CLI.Commands.Projects
{
    public class BuildProjectCommand : ICommand
    {
        public string Name { get; } = "build";

        private readonly IShell shell;

        public BuildProjectCommand(IShell shell)
        {
            this.shell = shell;
        }

        public Task Execute(string[] args)
        {
            Console.WriteLine("Build smth here");

            if (args.Length < 1)
            {
                Console.WriteLine("No command given");
                return Task.CompletedTask;
            }

            var result = this.shell.Run(args[0], args.Skip(1).ToArray());

            Console.WriteLine($"code: {result.Code}");
            if (result.Output.Length > 0)
                Console.Write($"stdout:{System.Environment.NewLine}{result.Output}");
            else
                Console.WriteLine("stdout is empty");

            if (result.Error.Length > 0)
                Console.Write($"stderr:{System.Environment.NewLine}{result.Error}");
            else
                Console.WriteLine("stderr is empty");

            return Task.CompletedTask;
        }
    }
}