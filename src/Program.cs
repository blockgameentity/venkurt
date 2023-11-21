using Serilog;

namespace venkurt;

internal static class Program
{
    private static void DeleteVencord()
    {
        if (!Directory.Exists(Constants.Directory)) return;
        
        Setup.GitDelete(Constants.Directory);
    }

    private static async Task Main()
    {
        using var mutex = new Mutex(false, $@"Global\{Constants.AppGuid}");
        if (!mutex.WaitOne(0, false)) return;
        
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        
        Deps.EnsureRequirements();
        DeleteVencord();
        Setup.Vencord();
        Setup.PhilsPlugins();
        await Setup.UserPlugins();
        await Patcher.PatchPlugins();
        Runner.RunCommand("pnpm", "build", Constants.Directory);
        Runner.RunCommand("pnpm", "inject", Constants.Directory);
    }
}