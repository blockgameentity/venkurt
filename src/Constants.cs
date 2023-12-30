namespace venkurt;

internal static class Constants
{
    public static readonly string Directory =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Vencord");

    public static readonly string[] OtherPluginsSparse = {
        "https://github.com/philhk/Vencord.git",
        "https://codeberg.org/lunaa/userPlugins.git"
    };
    public static readonly string[] OtherPlugins = {
        "https://github.com/Syncxv/vc-gif-collections.git",
        "https://github.com/Syncxv/vc-message-logger-enhanced.git",
        "https://github.com/Syncxv/vc-timezones"
    };
    public static readonly string[] PhilPluginNames = {
        "betterMicrophone.desktop",
        "betterScreenshare.desktop",
        "philsPluginLibrary"
    };
    public static readonly string[] Requirements = {
        "git",
        "pnpm",
        "nodejs"
    };
    
    public const string AppGuid = "9d029901-fa07-4cff-8282-1de5a75915c3";
}