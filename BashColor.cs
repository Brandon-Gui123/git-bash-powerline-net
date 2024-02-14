namespace GitBashPowerlineNET;

public static class BashColor
{
	/*
	 * In all these functions, I use double-backslashes in order to get the proper
	 * string that will be given to PS1 via the PROMPT_COMMAND.
	 * 
	 * Having Bash handle all the Unicode and escape intepretation will save some
	 * headache and effort.
	 */

	public static void PrintForeground(int code)
	{
		Console.Write($"\\[\\e[38;5;{code}m\\]");
	}

	public static void PrintBackground(int code)
	{
		Console.Write($"\\[\\e[48;5;{code}m\\]");
	}

	public static void PrintReset()
	{
		Console.Write("\\[\\e[0m\\]");
	}
}
