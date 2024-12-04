namespace Advent2024.Days;

// https://adventofcode.com/2024/day/3
public sealed partial class Day03 : MyBaseDay
{
    public override string? Part1TestInput { get; set; } = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

    public override string? Part2TestInput { get; set; } = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

    public Day03() => Input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        var sum = Part1MultiplyInstructionsRegex().Matches(Input)
            .Select(match => match.Groups.Values.Skip(1).Select(group => group.Value).Select(int.Parse))
            .Sum(numbers => numbers.Aggregate((num1, num2) => num1 * num2));

        return new(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new(string.Empty);
    }

    [GeneratedRegex(@"mul\(([0-9]{1,3}),([0-9]{1,3})\)")]
    private static partial Regex Part1MultiplyInstructionsRegex();
}
