#load "Command.csx"
#load "Git.csx"
using System.Text.RegularExpressions;

public static class ChangeLog
{
    static ChangeLog()
    {
        try
        {
            Command.Execute("cmd.exe", "/c gem install github_changelog_generator --prerelease --force");    
        }
        catch (System.Exception)
        {            
         //   throw;
        }
        
    }
    
    public static void Generate(string pathToChangeLog)
    {                
        bool isTagCommit = Git.IsTagCommit();        
        string sinceTag = isTagCommit ? Git.GetPreviousTag() : Git.GetLatestTag();
        var urlToPushOrigin = Git.GetUrlToPushOrigin();
        var match = Regex.Match(urlToPushOrigin, @".*.com\/(.*)\/(.*)\.");
        var user = match.Groups[1].Value;
        var project = match.Groups[2].Value;
        var token = Git.GetAccessToken();                
        var args = $"/c github_changelog_generator --user {user} --project {project} --since-tag {sinceTag} --token {token} --output {pathToChangeLog}";
        if (isTagCommit)
        {
            args = args + " --no-unreleased";            
        }        

        Command.Execute("cmd.exe",args);
        
    }
}