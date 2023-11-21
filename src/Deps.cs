using System.Diagnostics;
using System.Runtime.InteropServices;
using Serilog;

namespace venkurt;

internal static class Deps
{
    private static bool GetCommand(string command)
    {
        try
        {
            using var proc = new Process();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.FileName = "where";
            proc.StartInfo.Arguments = command;
            proc.StartInfo.CreateNoWindow = true;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                proc.StartInfo.FileName += "is";
            
            proc.Start();
            proc.WaitForExit();
            return proc.ExitCode is 0;
        }
        catch (Exception)
        {
            const string errorMessage = "'where' command is not in path";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new Exception(errorMessage);
            throw new Exception(errorMessage.Replace("where", "whereis"));
        }
    }

    public static void EnsureRequirements()
    {
        foreach (var requirement in Constants.Requirements)
        {
            if (GetCommand(requirement.Replace("js", string.Empty))) continue;

            Log.Error($"{requirement} is not installed!");
            Console.ReadLine();
            Environment.Exit(-1);
        }
    }
}