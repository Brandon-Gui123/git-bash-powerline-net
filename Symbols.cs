namespace GitBashPowerlineNET;

public static class Symbols
{
	public static string Get(Symbol symbol)
	{
		return symbol switch
		{
			Symbol.LEFT_HARD_DIVIDER => "\\ue0b0",
			Symbol.REPO_BRANCH => "\\uf418",
			Symbol.COMMIT => "\\uf4b6",
			Symbol.FILE_ADDED => "\\uf4d0",
			Symbol.FILE => "\\uf4a5",
			Symbol.FILE_REMOVED => "\\uf4d6",
			Symbol.FILE_MOVED => "\\uf4d5",
			Symbol.STAR => "\\uf4f5",
			Symbol.GIT_MERGE => "\\uf419",
			Symbol.CHERRY => "\\ue29b",
			Symbol.SEARCH => "\\uf422",
			Symbol.BUG => "\\uf46f",
			Symbol.ARROW_U_DOWN_LEFT => "\\udb85\\udfad",
			Symbol.HISTORY => "\\udb80\\udeda",
			Symbol.FLAG => "\\udb80\\ude40",

			_ => throw new ArgumentException("Unknown symbol argument!"),
		};
	}
}
