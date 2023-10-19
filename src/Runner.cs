using System.Diagnostics;

namespace venkurt;

internal static class Runner
{
    public static void RunCommand(string command, string args, string workDir = "")
    {
        var psi = new ProcessStartInfo
        {
            FileName = command,
            Arguments = args
        };

        if (workDir is not "") psi.WorkingDirectory = workDir;
        
        var proc = Process.Start(psi);

        proc?.WaitForExit();

        if (proc is { ExitCode: -1 })
            Reporter.Report(Reporter.Situation.ExitCode,
                $"\ncmd: {command} \nargs: {args} \nworkdir: {workDir} \nout: {proc.StandardOutput.ReadToEnd()}");
    }
}