using System;
using PreoccupiedGames.Evaluator;

public static class EquationCompiler
{
	public static Expression Compile(string equation)
	{
		Scanner scanner = new Scanner();
		scanner.SetSource(equation, 0);
		Parser parser = new Parser(scanner);
		parser.Parse();

		return parser.result;
	}
}

