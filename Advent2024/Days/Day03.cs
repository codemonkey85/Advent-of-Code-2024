namespace Advent2024.Days;

// https://adventofcode.com/2024/day/3
public sealed partial class Day03 : BaseDay
{
    private const bool TestMode = true;

    private readonly string input;

    private const string Part1TestInput = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

    private const string Part2TestInput = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

    public Day03() => input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        var localInput = TestMode ? Part1TestInput : input;

        var nums = Part1MultiplyInstructionsRegex()
            .Matches(localInput)
            .Select(match => match?.ToString()?[4..^1].Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse) ?? [])
            .ToList();

        var sum = nums.Sum(n => n.Aggregate((a, b) => a * b));

        return new(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var localInput = TestMode ? Part2TestInput : input;

        return new(string.Empty);
    }

    [GeneratedRegex(@"mul\([0-9]{1,3},[0-9]{1,3}\)")]
    private static partial Regex Part1MultiplyInstructionsRegex();
}
