using System.Diagnostics;
using System.Runtime.InteropServices;

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

    public static void InstallRequirements()
    {
        foreach (var requirement in Constants.Requirements)
        {
            if (GetCommand(requirement.Replace("js", string.Empty))) continue;

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.WriteLine($"{requirement} is not installed!");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            
            Console.WriteLine($"{requirement} is not installed! Would you like to install {requirement} using Scoop?" +
                              $" Scoop will also be installed if you do not have it. (Y/N) ");
            var input = Console.ReadKey();

            if (input.Key is ConsoleKey.Y)
            {
                if (!GetCommand("scoop"))
                    Runner.RunCommand("powershell", "\"Set-ExecutionPolicy RemoteSigned -Scope CurrentUser -Force; " +
                                                    "Invoke-RestMethod get.scoop.sh | Invoke-Expression\"");
                Runner.RunCommand("scoop", $"install {requirement}");
            }
            else
                Environment.Exit(-1);
        }
    }
}