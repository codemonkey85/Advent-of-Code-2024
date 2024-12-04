namespace Advent2024.Days;

// https://adventofcode.com/2024/day/2
public class Day02 : BaseDay
{
    private const bool TestMode = false;

    private readonly string Input;

    private const string TestInput = """
                                     7 6 4 2 1
                                     1 2 7 8 9
                                     9 7 6 2 1
                                     1 3 2 4 5
                                     8 6 4 4 1
                                     1 3 6 7 9
                                     """;

    public Day02() => Input = TestMode ? TestInput : File.ReadAllText(InputFilePath);

    private static List<List<int>> ParseInput(string input)
    {
        List<List<int>> reportsList = [];
        foreach (var line in input.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            List<int> report = [];
            foreach (var number in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                report.Add(int.Parse(number));
            }
            reportsList.Add(report);
        }

        return reportsList;
    }

    public override ValueTask<string> Solve_1()
    {
        var reportsList = ParseInput(Input);
        var numSafe = 0;
        for (var reportIndex = 0; reportIndex < reportsList.Count; reportIndex++)
        {
            var report = reportsList[reportIndex];

            if (IsReportSafe(report))
            {
                numSafe++;
            }
        }

        return new(numSafe.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var reportsList = ParseInput(Input);
        var numSafe = 0;
        for (var reportIndex = 0; reportIndex < reportsList.Count; reportIndex++)
        {
            var report = reportsList[reportIndex];

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
                    if (IsReportSafe(dampenedReoprt))
                    {
                        numSafe++;
                        break;
                    }
                }
            }
        }

        return new(numSafe.ToString());
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

            if (Math.Abs(num1 - num2) > 3)
            {
                safe = false;
                break;
            }
        }

        return safe;
    }
}
