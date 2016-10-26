using System.Diagnostics;

namespace Dockman.CLI.Platform
{
    public class NixShell : IShell
    {
        public ShellResult Run(string command, params string[] args)
        {
            var process = new Process();

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = string.Join(" ", args);

            process.Start();

            process.WaitForExit();

            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();

            return new ShellResult(process.ExitCode, output, error);
        }
    }
}