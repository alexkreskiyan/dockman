using System.Threading.Tasks;

namespace Dockman.CLI.Commands
{
    public interface ICommand
    {
        string Name { get; }

        Task Execute(string[] args);
    }
}