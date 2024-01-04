using System.Reflection;
using Serilog;

namespace venkurt;

internal static class Patcher
{
    private static void ReplaceStringInFile(string filePath, string oldString, string newString)
    {
        var content = File.ReadAllText(filePath);
        content = content.Replace(oldString, newString);
        if (!content.Contains(oldString))
            if (!content.Contains(newString))
                Log.Error($"Could not find {oldString} in {filePath}");

        File.WriteAllText(filePath, content);
    }

    public static async Task WriteResourceToFile(string name, string outputPath)
    {
        var assembly = Assembly.GetExecutingAssembly();
        await using var stream = assembly.GetManifestResourceStream(name);

        if (stream is null)
            throw new Exception($"{name}'s stream is null");

        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);
        await File.WriteAllBytesAsync(outputPath, memoryStream.ToArray());
    }

    private static async Task<string> ReadResource(string name)
    {
        var assembly = Assembly.GetExecutingAssembly();
        await using var stream = assembly.GetManifestResourceStream(name);

        if (stream is null)
            throw new Exception($"{name}'s stream is null");

        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }

    public static async Task PatchPlugins()
    {
        ReplaceStringInFile(
            Path.Combine(Constants.Directory, "src", "userplugins", "vc-message-logger-enhanced", "utils",
                "checkForUpdates.ts"), "await getUpdateVersion()", "false");
        foreach (var plugin in Constants.PhilPluginNames)
            ReplaceStringInFile(Path.Combine(Constants.Directory, "src", "plugins", plugin, "constants",
                "constants.ts"), "Devs.philhk", "Devs.phil");
        ReplaceStringInFile(Path.Combine(Constants.Directory, "src", "userplugins", "ToastNotifications", "index.tsx"), "[Devs.Skully]", "[{id:150298098516754432n, name:\"Skully\"}]");
        
        var philLib = Path.Combine(Constants.Directory, "src", "plugins", "philsPluginLibrary");

        // beautiful monstrosity
        ReplaceStringInFile(Path.Combine(philLib, "patches", "audio.ts"),
            "import { Logger } from \"@utils/Logger\";",
            "import { Logger } from \"@utils/Logger\"; import { valueDownmix } from \"userplugins/downmix\";");
        ReplaceStringInFile(Path.Combine(philLib, "patches", "audio.ts"), "audioEncoder: {",
            "audioDecoders: [{ ...connection.getCodecOptions(\"opus\").audioDecoders[0], params: { stereo: valueDownmix } }], audioEncoder: {");
        ReplaceStringInFile(Path.Combine(philLib, "components", "settingsPanel", "SettingsPanelButton.tsx"),
            "export const SettingsPanelButton = (props: SettingsPanelButtonProps) => {",
            "export const SettingsPanelButton = (props: SettingsPanelButtonProps) => { setTimeout(()=>{" +
            "const firstActionButtonContainer=(document.querySelector(`[aria-label=\"User area\"]`)as HTMLElement).children[1].children[0];" +
            "if(firstActionButtonContainer.parentElement?.childElementCount===2){" +
            "const secondActionButtonContainer=(firstActionButtonContainer.parentElement?.children[1]as HTMLElement);" +
            "firstActionButtonContainer.appendChild(secondActionButtonContainer)}},500);");

        await File.WriteAllTextAsync(
            Path.Combine(philLib, "components",
                "ContributorAuthorSummary.tsx"), await ReadResource("venkurt.files.ContributorAuthorSummary.tsx"));
        await File.WriteAllTextAsync(
            Path.Combine(philLib, "icons", "index.tsx"),
            await ReadResource("venkurt.files.index.tsx"));
    }
}