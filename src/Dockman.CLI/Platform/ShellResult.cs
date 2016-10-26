namespace Dockman.CLI.Platform
{
    public class ShellResult
    {
        public int Code { get; }

        public string Output { get; }

        public string Error { get; }

        public ShellResult(int code, string output, string error)
        {
            this.Code = code;
            this.Output = output;
            this.Error = error;
        }
    }
}