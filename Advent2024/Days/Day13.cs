namespace Advent2024.Days;

// https://adventofcode.com/2024/day/13
public sealed class Day13 : MyBaseDay
{
    public override string? Part1TestInput { get; set; } = """
                                                           Button A: X+94, Y+34
                                                           Button B: X+22, Y+67
                                                           Prize: X=8400, Y=5400
                                                           
                                                           Button A: X+26, Y+66
                                                           Button B: X+67, Y+21
                                                           Prize: X=12748, Y=12176
                                                           
                                                           Button A: X+17, Y+86
                                                           Button B: X+84, Y+37
                                                           Prize: X=7870, Y=6450
                                                           
                                                           Button A: X+69, Y+23
                                                           Button B: X+27, Y+71
                                                           Prize: X=18641, Y=10279
                                                           """;

    public Day13() => Input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        return new(string.Empty);
    }

    public override ValueTask<string> Solve_2()
    {
        return new(string.Empty);
    }
}
