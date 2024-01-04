using System.IO.Compression;
using Serilog;

namespace venkurt;

internal static class Setup
{
    public static void Vencord()
    {
        Runner.RunCommand("git", "clone https://github.com/Vendicated/Vencord",
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        Runner.RunCommand("pnpm", "install --frozen-lockfile", Constants.Directory);
    }

    private static void SetAttributesRecursively(DirectoryInfo di)
    {
        foreach (var di2 in di.EnumerateDirectories())
        {
            SetAttributesRecursively(di2);
        }

        foreach (var fi in di.EnumerateFiles())
        {
            Log.Information($"Setting {fi.FullName}'s file attributes to normal");
            File.SetAttributes(fi.FullName, FileAttributes.Normal);
        }
    }

    public static void GitDelete(string dir)
    {
        var gitDi = new DirectoryInfo(Path.Combine(dir, ".git"));
        if (gitDi.Exists)
            SetAttributesRecursively(gitDi);

        if (dir == Constants.Directory)
        {
            var di = new DirectoryInfo(Path.Combine(dir, "src", "userplugins"));
            SetAttributesRecursively(di);
        }

        a:
        try
        {
            Directory.Delete(dir, true);
        }
        catch (UnauthorizedAccessException ex) when (ex.Message.Contains("Access to the path"))
        {
            Thread.Sleep(100);
            Log.Error($"Could not access {dir}! Trying again...");
            goto a;
        }
    }

    public static void PhilsPlugins()
    {
        var philDir = Path.Combine(Constants.Directory, "phil");
        Runner.RunCommand("git", $"clone -n --depth=1 --filter=tree:0 {Constants.OtherPluginsSparse[0]} phil",
            Constants.Directory);

        var sparse = Constants.PhilPluginNames.Aggregate("sparse-checkout set --no-cone ",
            (current, plugin) => current + $"src/plugins/{plugin} ");
        Runner.RunCommand("git", sparse, philDir);
        Runner.RunCommand("git", "checkout", philDir);

        foreach (var plugin in Constants.PhilPluginNames)
        {
            Directory.Move(Path.Combine(philDir, "src", "plugins", plugin),
                Path.Combine(Constants.Directory, "src", "plugins", plugin));
        }

        GitDelete(philDir);
    }

    public static async Task UserPlugins()
    {
        var userplugs = Path.Combine(Constants.Directory, "src", "userplugins");
        Directory.CreateDirectory(userplugs);
        await Patcher.WriteResourceToFile("venkurt.files.a.zip", Path.Combine(userplugs, "a.zip"));
        ZipFile.ExtractToDirectory(Path.Combine(userplugs, "a.zip"), userplugs);
        File.Delete(Path.Combine(userplugs, "a.zip"));

        foreach (var plugin in Constants.OtherPlugins)
            Runner.RunCommand("git", $"clone {plugin}", userplugs);
        
        var lunaDir = Path.Combine(Constants.Directory, "luna");
        Runner.RunCommand("git", $"clone -n --depth=1 --filter=tree:0 {Constants.OtherPluginsSparse[1]} luna",
            Constants.Directory);
        Runner.RunCommand("git", "sparse-checkout set --no-cone bannersEverywhere", lunaDir);
        Runner.RunCommand("git", "checkout", lunaDir);
        
        Directory.Move(Path.Combine(lunaDir, "bannersEverywhere"),
            Path.Combine(Constants.Directory, "src", "userplugins", "bannersEverywhere"));
        
        GitDelete(lunaDir);
        
        var skullyDir = Path.Combine(Constants.Directory, "skully");
        Runner.RunCommand("git", $"clone -n --depth=1 --filter=tree:0 {Constants.OtherPluginsSparse[2]} skully",
            Constants.Directory);
        Runner.RunCommand("git", "sparse-checkout set --no-cone src/plugins/ToastNotifications", skullyDir);
        Runner.RunCommand("git", "checkout", skullyDir);
        
        Directory.Move(Path.Combine(skullyDir, "src", "plugins", "ToastNotifications"),
            Path.Combine(Constants.Directory, "src", "userplugins", "ToastNotifications"));
        
        GitDelete(skullyDir);
    }
}