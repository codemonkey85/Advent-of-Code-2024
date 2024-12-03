namespace Advent2024.Days;

// https://adventofcode.com/2024/day/1
public sealed class Day01 : BaseDay
{
    private const bool TestMode = true;

    private readonly string Input;

    private const string TestInput = """
                                     3   4
                                     4   3
                                     2   5
                                     1   3
                                     3   9
                                     3   3
                                     """;

    public Day01() => Input = TestMode ? TestInput : File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        return new(string.Empty);
    }

    public override ValueTask<string> Solve_2()
    {
        return new(string.Empty);
    }
}
