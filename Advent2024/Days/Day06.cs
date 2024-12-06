namespace Advent2024.Days;

// https://adventofcode.com/2024/day/6
public sealed class Day06 : MyBaseDay
{
    public override string? Part1TestInput { get; set; } = """
        ....#.....
        .........#
        ..........
        ..#.......
        .......#..
        ..........
        .#..^.....
        ........#.
        #.........
        ......#...
        """;

    public Day06() => Input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        return new(string.Empty);
    }

    public override ValueTask<string> Solve_2()
    {
        return new(string.Empty);
    }
}
