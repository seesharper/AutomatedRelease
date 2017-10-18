#load "Command.csx"

public static class Git
{
    public static string GetCurrentTag()
    {
        return Command.Execute("git", "describe --exact-match --tags HEAD", true);
    }

    public static string GetPreviousTag()
    {
        return Command.Execute("git", "describe --abbrev=0 --tags `git rev-list --tags --skip=1 --max-count=1`", true);
    }
}