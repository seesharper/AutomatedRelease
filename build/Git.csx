#load "Command.csx"

public static class Git
{
    public static string GetCurrentTag()
    {        
        var result =  Command.Capture("git", "describe --exact-match --tags HEAD");
        if (result.exitCode == 0)
        {
            return result.output.Replace(Environment.NewLine,"");
        }
        else
        {
            return string.Empty;
        }
    }

    public static string GetPreviousTag()
    {        
        var result = Command.Capture("git","describe --abbrev=0 --tags `git rev-list --tags --skip=1 --max-count=1`");
        if (result.exitCode == 0)
        {
            return result.output.Replace(Environment.NewLine,"");
        }
        else
        {
            return string.Empty;
        }
    }

    private static string GetPreviousCommitHash()
    {
        var result = Command.Capture("git", "rev-list --tags --skip=1 --max-count=1");
        if (result.exitCode == 0)
        {
            return result.output.Replace(Environment.NewLine, "");
        }
        else
        {
            return string.Empty;
        }
    }
}