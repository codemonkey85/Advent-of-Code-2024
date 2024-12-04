namespace Advent2024.Days;

public class MyBaseDay : BaseDay
{
    public string Input { get; set; } = string.Empty;

    public virtual string? Part1TestInput { get; set; }

    public virtual string? Part2TestInput { get; set; }

    public override ValueTask<string> Solve_1() => throw new NotImplementedException();

    public override ValueTask<string> Solve_2() => throw new NotImplementedException();
}
