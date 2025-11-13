namespace Advent2024.Days;

// https://adventofcode.com/2024/day/12
public sealed class Day12 : MyBaseDay
{
    public override string? Part1TestInput { get; set; } = """
                                                           AAAA
                                                           BBCD
                                                           BBCC
                                                           EEEC
                                                           """;

    public Day12() => Input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        return new(string.Empty);
    }

    public override ValueTask<string> Solve_2()
    {
        return new(string.Empty);
    }
}
