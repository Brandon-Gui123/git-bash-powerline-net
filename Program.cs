using LibGit2Sharp;
using GitBashPowerlineNET;

Segments.PrintCurrentUserName(13, 17);
Segments.PrintLeftHardDivider(17, 18);

Segments.PrintWorkingDirectory(3, 18);

string repoPath = Repository.Discover(Environment.CurrentDirectory);

if (repoPath != null)
{
	using Repository repo = new(repoPath);

	Segments.PrintLeftHardDivider(18, 19);
	Segments.PrintRepositoryHeadAndOperation(15, 19, in repo);
	Segments.PrintLeftHardDivider(19);
}
else
{
	Segments.PrintLeftHardDivider(18);
}

Segments.PrintNewline();

string exitCode = args[0];
if (exitCode != "0")
{
	Segments.PrintExitCode(1, 52, exitCode);
	Segments.PrintLeftHardDivider(52, 53);
}

Segments.PrintPromptSymbol(10, 53);
Segments.PrintLeftHardDivider(53);
