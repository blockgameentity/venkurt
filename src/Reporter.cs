namespace venkurt;

internal static class Reporter
{
    public enum Situation
    {
        ExitCode,
        NothingToPatch
    }

    public static void Report(Situation situation, string failMsg) => throw new Exception(
        $"Situation: {situation}, Message: \n{failMsg}");
}