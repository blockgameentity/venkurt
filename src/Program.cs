using System.Runtime.InteropServices;

namespace venkurt;

internal static class Program
{
    private static void DeleteVencord()
    {
        if (!Directory.Exists(Constants.Directory)) return;
        
        // I tried using Directory.Delete(Constants.Directory, true); but it always failed me with some kind of
        // odd access denied error on a git file even though it wasn't even being used!
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            Runner.RunCommand("powershell", $"\"Remove-Item '{Constants.Directory}' -Recurse -Force\"");
        else
            Runner.RunCommand("rm", $"-rf \"{Constants.Directory}\"");
    }

    private static async Task Main()
    {
        using var mutex = new Mutex(false, $@"Global\{Constants.AppGuid}");
        if (!mutex.WaitOne(0, false)) return;
        
        Deps.InstallRequirements();
        DeleteVencord();
        Setup.Vencord();
        Setup.PhilsPlugins();
        await Setup.UserPlugins();
        await Patcher.PatchPlugins();
        Runner.RunCommand("pnpm", "build", Constants.Directory);
        Runner.RunCommand("pnpm", "inject", Constants.Directory);
    }
}