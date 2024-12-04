namespace Advent2024.Days;

// https://adventofcode.com/2024/day/1
public sealed class Day01 : MyBaseDay
{
    public override string? Part1TestInput { get; set; } = """
        3   4
        4   3
        2   5
        1   3
        3   9
        3   3
        """;

    public Day01() => Input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        var (leftNumbers, rightNumbers) = ParseInput();

        var distanceTotal = leftNumbers
            .Select((left, index) => Math.Abs(left - rightNumbers[index]))
            .Sum();

        return new(distanceTotal.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var (leftNumbers, rightNumbers) = ParseInput();

        var similarityScore = leftNumbers
            .Select(leftNumber => rightNumbers.Count(rightNumber => rightNumber == leftNumber) * leftNumber)
            .Sum();

        return new(similarityScore.ToString());
    }

    private (List<int> leftNumbers, List<int> rightNumbers) ParseInput()
    {
        List<int> leftNumbers = [];
        List<int> rightNumbers = [];

        foreach (var line in Input.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            leftNumbers.Add(int.Parse(numbers[0]));
            rightNumbers.Add(int.Parse(numbers[1]));
        }

        leftNumbers.Sort();
        rightNumbers.Sort();

        return (leftNumbers, rightNumbers);
    }
}
