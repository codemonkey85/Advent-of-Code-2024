namespace Advent2024.Days;

// https://adventofcode.com/2024/day/1
public class Day01 : MyBaseDay
{
    public Day01() => Input = File.ReadAllText(InputFilePath);

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
                throw new("Index out of range");
            }

            var right = rightNumbers[index];

            distanceTotal += Math.Abs(right - left);
        }

        return new(distanceTotal.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var (leftNumbers, rightNumbers) = ParseInput(Input);
        var similarityScore = (
            from leftNumber in leftNumbers
            let count = rightNumbers.Count(rightNumber => rightNumber == leftNumber)
            select count * leftNumber)
            .Sum();

        return new(similarityScore.ToString());
    }
}
