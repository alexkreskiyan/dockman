using System.Diagnostics;

namespace Dockman.CLI.Platform
{
    public class WinShell : IShell
    {
        public ShellResult Run(string command, params string[] args)
        {
            var process = new Process();

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/C {command} {string.Join(" ", args)}";

            process.Start();

            process.WaitForExit();

            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();

            return new ShellResult(process.ExitCode, output, error);
        }
    }
}