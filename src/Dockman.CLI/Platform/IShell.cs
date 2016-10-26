namespace Dockman.CLI.Platform
{
    public interface IShell
    {
        ShellResult Run(string command, params string[] args);
    }
}