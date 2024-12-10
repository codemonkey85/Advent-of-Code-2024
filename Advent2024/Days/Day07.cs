namespace Advent2024.Days;

// https://adventofcode.com/2024/day/7
public sealed class Day07 : MyBaseDay
{
    public override string? Part1TestInput { get; set; } = """
                                                           190: 10 19
                                                           3267: 81 40 27
                                                           83: 17 5
                                                           156: 15 6
                                                           7290: 6 8 6 15
                                                           161011: 16 10 13
                                                           192: 17 8 14
                                                           21037: 9 7 18 13
                                                           292: 11 6 16 20
                                                           """;

    public Day07() => Input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        var lines = ParseInput();
        var sum = 0;

        foreach (var line in lines)
        {
        }

        return new(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new(string.Empty);
    }

    private List<Line> ParseInput()
    {
        var lineStrings = Input.Replace("\r", string.Empty).Split("\n", StringSplitOptions.RemoveEmptyEntries);
        return (
            from lineString in lineStrings
            select lineString.Split(": ")
            into parts
            let testValue = int.Parse(parts[0])
            let numbers = parts[1].Split(" ").Select(int.Parse).ToList()
            select new Line(testValue, numbers)).ToList();
    }

    private record Line(int TestValue, List<int> Numbers);
}
