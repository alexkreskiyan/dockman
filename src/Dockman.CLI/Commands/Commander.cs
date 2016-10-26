using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dockman.CLI.Commands
{
    public class Commander
    {
        private readonly IList<ICommand> commands = new List<ICommand>();

        public async Task Run(string cmd)
        {
            if (cmd.Length == 0)
                return;

            //find longest matching command
            var command = this.FindCommand(cmd);
            if (command == null)
            {
                Console.WriteLine($"No command found, matching given command string: {cmd}");
                return;
            }

            try
            {
                await command.Execute(this.GetCommandArgs(command.Name, cmd));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void Register(ICommand command) => this.commands.Add(command);

        private ICommand FindCommand(string cmd)
            => this.commands
                .OrderByDescending(command => command.Name.Length)
                .FirstOrDefault(command => cmd.StartsWith(command.Name));

        private string[] GetCommandArgs(string command, string cmd)
            => cmd.Substring(command.Length)
                .Split(' ')
                .Select(arg => arg.Trim())
                .Where(arg => !string.IsNullOrWhiteSpace(arg))
                .ToArray();
    }
}