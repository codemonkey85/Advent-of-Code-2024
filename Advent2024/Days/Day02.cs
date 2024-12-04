namespace Advent2024.Days;

// https://adventofcode.com/2024/day/2
public class Day02 : BaseDay
{
    private readonly string input;

    public Day02() => input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        var reportsList = ParseInput(input);
        var numSafe = reportsList.Count(IsReportSafe);

        return new(numSafe.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var reportsList = ParseInput(input);
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

    private static List<List<int>> ParseInput(string input)
    {
        List<List<int>> reportsList = [];
        foreach (var line in input.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            List<int> report = [];
            report.AddRange(line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            reportsList.Add(report);
        }

        return reportsList;
    }

    private static bool IsReportSafe(List<int> report)
    {
        var safe = true;
        var increasing = false;
        var decreasing = false;

        for (var col = 0; col < report.Count - 1; col++)
        {
            var num1 = report[col];
            var num2 = col + 1 < report.Count ? report[col + 1] : 0;

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
                safe = false;
                break;
            }

            if (Math.Abs(num1 - num2) < 1)
            {
                safe = false;
                break;
            }

            if (Math.Abs(num1 - num2) <= 3)
            {
                continue;
            }

            safe = false;
            break;
        }

        return safe;
    }
}
