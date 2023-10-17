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

    public static void PhilsPlugins()
    {
        Runner.RunCommand("git", "clone https://github.com/philhk/Vencord phil", Constants.Directory);
        foreach (var plugin in Constants.PhilPluginNames)
        {
            Directory.Move(Path.Combine(Constants.Directory, "phil", "src", "plugins", plugin),
                Path.Combine(Constants.Directory, "src", "plugins", plugin));
        }

        Runner.RunCommand("powershell", $"\"Remove-Item '{Path.Combine(Constants.Directory, "phil")}' -Recurse -Force\"");
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
    }
}