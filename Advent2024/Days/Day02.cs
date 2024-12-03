namespace Advent2024.Days;

// https://adventofcode.com/2024/day/2
public sealed class Day02 : BaseDay
{
    const bool TestMode = true;

    private readonly string Input = string.Empty;

    private readonly string TestInput =
        """
        7 6 4 2 1
        1 2 7 8 9
        9 7 6 2 1
        1 3 2 4 5
        8 6 4 4 1
        1 3 6 7 9
        """;

    public Day02() => Input = TestMode ? TestInput : File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        return new(string.Empty);
    }

    public override ValueTask<string> Solve_2()
    {
        return new(string.Empty);
    }
}
