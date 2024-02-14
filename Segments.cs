using LibGit2Sharp;

namespace GitBashPowerlineNET;

public static class Segments
{
	public static void PrintWorkingDirectory(int fgCode, int bgCode)
	{
		BashColor.PrintForeground(fgCode);
		BashColor.PrintBackground(bgCode);

		// in PS1, \w will be reintepreted as the current working directory
		Console.Write(" \\w ");

		BashColor.PrintReset();
	}

	public static void PrintCurrentUserName(int fgCode, int bgCode)
	{
		BashColor.PrintForeground(fgCode);
		BashColor.PrintBackground(bgCode);

		// in PS1, \u will be reintepreted as the current user's name
		Console.Write(" \\u ");

		BashColor.PrintReset();
	}

	public static void PrintPromptSymbol(int fgCode, int bgCode)
	{
		BashColor.PrintForeground(fgCode);
		BashColor.PrintBackground(bgCode);

		Console.Write(" $ ");

		BashColor.PrintReset();
	}

	public static void PrintLeftHardDivider(int fgCode)
	{
		BashColor.PrintForeground(fgCode);

		Console.Write(Symbols.Get(Symbol.LEFT_HARD_DIVIDER));

		BashColor.PrintReset();
	}

	public static void PrintLeftHardDivider(int fgCode, int bgCode)
	{
		BashColor.PrintForeground(fgCode);
		BashColor.PrintBackground(bgCode);

		Console.Write(Symbols.Get(Symbol.LEFT_HARD_DIVIDER));

		BashColor.PrintReset();
	}

	public static void PrintNewline()
	{
		// remember, we're feeding this to Bash, who will feed this to PS1
		Console.Write("\\n");
	}

	public static void PrintRepositoryHeadAndOperation(int fgCode, int bgCode, in Repository repo)
	{
		BashColor.PrintForeground(fgCode);
		BashColor.PrintBackground(bgCode);

		if (repo.Info.IsHeadDetached)
		{
			Console.Write($" {Symbols.Get(Symbol.COMMIT)} {repo.Head.Tip.Sha.Remove(6)} ");
		}
		else
		{
			Console.Write($" {Symbols.Get(Symbol.REPO_BRANCH)} {repo.Head.FriendlyName} ");
		}

		BashColor.PrintForeground(202);
		CurrentOperation currentOperation = repo.Info.CurrentOperation;
		switch (currentOperation)
		{
			case CurrentOperation.Merge:
				Console.Write($"{Symbols.Get(Symbol.GIT_MERGE)} ");
				break;

			case CurrentOperation.CherryPick:
			case CurrentOperation.CherryPickSequence:
				Console.Write($"{Symbols.Get(Symbol.CHERRY)} ");
				break;

			case CurrentOperation.Bisect:
				Console.Write($"{Symbols.Get(Symbol.SEARCH)} ");
				break;

			case CurrentOperation.Rebase:
			case CurrentOperation.RebaseInteractive:
			case CurrentOperation.RebaseMerge:
				Console.Write($"{Symbols.Get(Symbol.ARROW_U_DOWN_LEFT)} ");
				break;

			case CurrentOperation.Revert:
			case CurrentOperation.RevertSequence:
				// \\040 is one way to intentionally have Bash intentionally intepret a space and thus, insert it
				Console.Write($"{Symbols.Get(Symbol.HISTORY)} \\040");
				break;
		}

		BashColor.PrintReset();
	}

	public static void PrintExitCode(int fgCode, int bgCode, string exitCode)
	{
		BashColor.PrintForeground(fgCode);
		BashColor.PrintBackground(bgCode);

		Console.Write($" {Symbols.Get(Symbol.FLAG)} {exitCode} ");

		BashColor.PrintReset();
	}
}
