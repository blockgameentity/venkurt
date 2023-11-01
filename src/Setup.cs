using System.IO.Compression;

namespace venkurt;

internal static class Setup
{
    public static void Vencord()
    {
        Runner.RunCommand("git", "clone https://github.com/Vendicated/Vencord",
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        Runner.RunCommand("pnpm", "install --frozen-lockfile", Constants.Directory);
    }


    public static void GitDelete(string dir)
    {
        var gitDi = new DirectoryInfo(Path.Combine(dir, ".git", "objects", "pack"));
        if (gitDi.Exists)
        {
            foreach (var fi in gitDi.EnumerateFiles())
                File.SetAttributes(fi.FullName, FileAttributes.Normal);
        }

        if (dir == Constants.Directory)
            foreach (var plugin in Constants.OtherPlugins)
            {
                var di = new DirectoryInfo(Path.Combine(dir, "src", "userplugins",
                    plugin[(plugin.LastIndexOf('/') + 1)..].Replace(".git", string.Empty), ".git", "objects", "pack"));
                if (!di.Exists) continue;
                foreach (var fi in di.EnumerateFiles())
                    File.SetAttributes(fi.FullName, FileAttributes.Normal);
            }

        a:
        try
        {
            Directory.Delete(dir, true);
        }
        catch (UnauthorizedAccessException ex) when (ex.Message.Contains("Access to the path"))
        {
            Thread.Sleep(100);
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
    }
}