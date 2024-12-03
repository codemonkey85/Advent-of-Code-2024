namespace Advent2024.Days;

// https://adventofcode.com/2024/day/3
public sealed class Day03 : BaseDay
{
    private const bool TestMode = true;

    private readonly string Input;

    private const string TestInput = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

    public Day03() => Input = TestMode ? TestInput : File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        return new(string.Empty);
    }

    public override ValueTask<string> Solve_2()
    {
        return new(string.Empty);
    }
}
