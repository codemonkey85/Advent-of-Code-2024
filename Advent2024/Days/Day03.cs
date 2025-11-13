using System.Diagnostics.CodeAnalysis;

namespace Advent2024.Days;

// https://adventofcode.com/2024/day/3
public sealed partial class Day03 : MyBaseDay
{
    private const string Num1 = "num1";
    private const string Num2 = "num2";

    public override string? Part1TestInput { get; set; } =
        "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

    public override string? Part2TestInput { get; set; } =
        "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

    public Day03() => Input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        var sum = Part1MultiplyInstructionsRegex().Matches(Input)
            .Select(match => (int.Parse(match.Groups[Num1].Value), int.Parse(match.Groups[Num2].Value)))
            .Aggregate(0, (acc, nums) => acc + nums.Item1 * nums.Item2);

        return new(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        const string mul = "mul";
        const string @do = "do";
        const string dont = "dont";

        var isEnabled = true; // Start with mul instructions enabled
        var sum = 0;

        // Iterate through all matches in the input
        foreach (Match match in Part2MultiplyInstructionsRegex().Matches(Input))
        {
            if (match.Groups[@do].Success)
            {
                isEnabled = true; // Enable mul instructions
            }
            else if (match.Groups[dont].Success)
            {
                isEnabled = false; // Disable mul instructions
            }
            else if (isEnabled && match.Groups[mul].Success)
            {
                // Extract numbers from mul(X,Y)
                var num1 = int.Parse(match.Groups[Num1].Value);
                var num2 = int.Parse(match.Groups[Num2].Value);
                sum += num1 * num2; // Multiply and add to the sum
            }
        }

        return new(sum.ToString());
    }

    [StringSyntax(StringSyntaxAttribute.Regex)]
    private const string MulRegex = @"(?<mul>mul\((?<num1>[0-9]{1,3}),(?<num2>[0-9]{1,3})\))";

    [StringSyntax(StringSyntaxAttribute.Regex)]
    private const string DoRegex = @"(?<do>do\(\))";

    [StringSyntax(StringSyntaxAttribute.Regex)]
    private const string DontRegex = @"(?<dont>don't\(\))";

    [GeneratedRegex(MulRegex)]
    private static partial Regex Part1MultiplyInstructionsRegex();

    [GeneratedRegex($"{MulRegex}|{DoRegex}|{DontRegex}")]
    private static partial Regex Part2MultiplyInstructionsRegex();
}
