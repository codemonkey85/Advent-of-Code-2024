namespace Advent2024.Days;

public sealed class Day01 : BaseLibraryDay
{
    private readonly string input;

    private const string TestInput = """
                                     
                                     """;

    public Day01() =>
        input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        return new(string.Empty);
    }

    public override ValueTask<string> Solve_2()
    {
        return new(string.Empty);
    }
}
