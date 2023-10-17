using System.Diagnostics;

namespace venkurt;

internal static class Runner
{
    public static void RunCommand(string command, string args, string workDir = "")
    {
        var psi = new ProcessStartInfo
        {
            FileName = command,
            Arguments = args,
            WorkingDirectory = workDir,
            RedirectStandardOutput = true,
            UseShellExecute = false
        };

        var proc = Process.Start(psi);
        
        proc?.WaitForExit();

        if (proc?.ExitCode is -1)
        {
            Reporter.Report(Reporter.Situation.ExitCode,
                $"\ncmd: {command} \nargs: {args} \nworkdir: {workDir} \nout: {proc.StandardOutput.ReadToEnd()}");
        }
    }
}