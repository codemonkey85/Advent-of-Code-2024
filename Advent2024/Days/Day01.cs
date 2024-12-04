namespace Advent2024.Days;

// https://adventofcode.com/2024/day/1
public class Day01 : BaseDay
{
    private const bool TestMode = false;

    private readonly string Input;

    private const string TestInput = """
                                     3   4
                                     4   3
                                     2   5
                                     1   3
                                     3   9
                                     3   3
                                     """;

    public Day01() => Input = TestMode ? TestInput : File.ReadAllText(InputFilePath);

    private static (List<int> leftNumbers, List<int> rightNumbers) ParseInput(string input)
    {
        IList<int> leftNumbers = [];
        IList<int> rightNumbers = [];

        foreach (var line in input.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            leftNumbers.Add(int.Parse(numbers[0]));
            rightNumbers.Add(int.Parse(numbers[1]));
        }

        return ([.. leftNumbers.Order()], [.. rightNumbers.Order()]);
    }

    public override ValueTask<string> Solve_1()
    {
        var (leftNumbers, rightNumbers) = ParseInput(Input);

        var distanceTotal = 0;

        foreach (var (index, left) in leftNumbers.Index())
        {
            if (index >= rightNumbers.Count)
            {
                throw new Exception("Index out of range");
            }

            var right = rightNumbers[index];

            distanceTotal += Math.Abs(right - left);
        }

        return new(distanceTotal.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var (leftNumbers, rightNumbers) = ParseInput(Input);
        var similarityScore = 0;
        foreach (var leftNumber in leftNumbers)
        {
            var count = rightNumbers.Count(rightNumber => rightNumber == leftNumber);
            similarityScore += count * leftNumber;
        }

        return new(similarityScore.ToString());
    }
}
