#! "netcoreapp1.1"
#r "nuget:NetStandard.Library,1.6.1"
#r "nuget:Octokit, 0.27.0"
#load "Git.csx"


using System.Net.Http;
using Octokit;


var currentTag = Git.GetCurrentTag();



var accessToken = System.Environment.GetEnvironmentVariable("GITHUB_REPO_TOKEN");
var client = new GitHubClient(new ProductHeaderValue("dotnet-script"));
var tokenAuth = new Credentials(accessToken); 
client.Credentials = tokenAuth;

// Get the current tag 



var newRelease = new NewRelease("1.0.0");
newRelease.Name = "Version One Point Oh";
newRelease.Body = "**This** is some *Markdown*";
newRelease.Draft = true;
newRelease.Prerelease = false;

var result = await client.Repository.Release.Create("seesharper", "automatedrelease", newRelease);
var test = await client.Git.Tag.Get("","","");











