#! "netcoreapp1.1"
#r "nuget:NetStandard.Library,1.6.1"
#r "nuget:Octokit, 0.27.0"
#load "Git.csx"
#load "Changelog.csx"
#load "BuildContext.csx"
#load "DotNet.csx"
#load "FileUtils.csx"
#load "GitHub.csx"
#load "NuGet.csx"

DotNet.Build(BuildContext.PathToProjectFolder);
DotNet.Publish(BuildContext.PathToProjectFolder);
DotNet.Pack(BuildContext.PathToProjectFolder, BuildContext.NuGetPackagesFolder);
GitHub.Pack(BuildContext.PathToPublishFolder, BuildContext.GitHubReleaseFolder);

if (Git.IsOnMaster() && Git.IsTagCommit())
{        
    NuGet.Push(BuildContext.NuGetPackagesFolder);
    GitHub.CreateReleaseDraft(BuildContext.GitHubReleaseFolder);       
}