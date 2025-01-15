namespace Advent2024.Days;

// https://adventofcode.com/2024/day/2
public sealed class Day02 : MyBaseDay
{
    public override string? Part1TestInput { get; set; } = """
                                                           7 6 4 2 1
                                                           1 2 7 8 9
                                                           9 7 6 2 1
                                                           1 3 2 4 5
                                                           8 6 4 4 1
                                                           1 3 6 7 9
                                                           """;

    public Day02() => Input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        var reportsList = ParseInput();
        var numSafe = reportsList.Count(IsReportSafe);

        return new(numSafe.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var reportsList = ParseInput();
        var numSafe = 0;

        foreach (var report in reportsList)
        {
            if (IsReportSafe(report))
            {
                numSafe++;
            }
            else
            {
                for (var col = 0; col < report.Count; col++)
                {
                    List<int> dampenedReoprt = [.. report];
                    dampenedReoprt.RemoveAt(col);

                    if (!IsReportSafe(dampenedReoprt))
                    {
                        continue;
                    }

                    numSafe++;
                    break;
                }
            }
        }

        return new(numSafe.ToString());
    }

    private List<List<int>> ParseInput() =>
        Input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList())
            .ToList();

    private static bool IsReportSafe(List<int> report)
    {
        var increasing = false;
        var decreasing = false;

        for (var col = 0; col < report.Count - 1; col++)
        {
            var num1 = report[col];
            var num2 = report[col + 1];

            if (num1 > num2)
            {
                decreasing = true;
            }

            if (num1 < num2)
            {
                increasing = true;
            }

            if (increasing && decreasing)
            {
                return false;
            }

            var diff = Math.Abs(num1 - num2);
            if (diff is < 1 or > 3)
            {
                return false;
            }
        }

        return true;
    }
}
