namespace Advent2024.Days;

// https://adventofcode.com/2024/day/5
public sealed class Day05 : MyBaseDay
{
    public override string? Part1TestInput { get; set; } = """
                                                           47|53
                                                           97|13
                                                           97|61
                                                           97|47
                                                           75|29
                                                           61|13
                                                           75|53
                                                           29|13
                                                           97|29
                                                           53|29
                                                           61|53
                                                           97|53
                                                           61|29
                                                           47|13
                                                           75|47
                                                           97|75
                                                           47|61
                                                           75|61
                                                           47|29
                                                           75|13
                                                           53|13

                                                           75,47,61,53,29
                                                           97,61,53,29,13
                                                           75,29,13
                                                           75,97,47,61,53
                                                           61,13,29
                                                           97,13,75,29,47
                                                           """;

    private List<Rule> rules = [];

    public Day05() => Input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        var pagesLists = ParseInput();

        var validPagesLists = (
            from pagesList in pagesLists
            let isValid = rules
                .Where(rule => pagesList.Contains(rule.First) && pagesList.Contains(rule.Second))
                .All(rule => pagesList.IndexOf(rule.First) <= pagesList.IndexOf(rule.Second))
            where isValid
            select pagesList).ToList();

        var sum = GetSum(validPagesLists);

        return new(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var pagesLists = ParseInput();

        var invalidPagesLists = (
            from pagesList in pagesLists
            let isValid = rules
                .Where(rule => pagesList.Contains(rule.First) && pagesList.Contains(rule.Second))
                .All(rule => pagesList.IndexOf(rule.First) <= pagesList.IndexOf(rule.Second))
            where !isValid
            select pagesList).ToList();

        foreach (var pagesList in invalidPagesLists)
        {
            pagesList.Sort(PagesComparer);
        }

        var sum = GetSum(invalidPagesLists);

        return new(sum.ToString());
    }

    private List<List<int>> ParseInput()
    {
        var inputParts = Input.Replace("\r", string.Empty).Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

        var ruleLines = inputParts.First().Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
        var pageLines = inputParts.Last().Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();

        rules = (
            from line in ruleLines
            select line.Split('|', StringSplitOptions.RemoveEmptyEntries)
            into parts
            let first = int.Parse(parts.First())
            let second = int.Parse(parts.Last())
            select new Rule(first, second)
        ).ToList();

        var pagesLists = pageLines
            .Select(line => line.Split(',', StringSplitOptions.RemoveEmptyEntries))
            .Select(parts => parts.Select(int.Parse).ToList())
            .ToList();

        return pagesLists;
    }

    private static int GetSum(List<List<int>> pagesLists) => (
        from pagesList in pagesLists
        let length = pagesList.Count
        let middle = length / 2
        select pagesList[middle]
    ).Sum();

    private Comparer<int> PagesComparer => Comparer<int>.Create((a, b) =>
    {
        var result = 0;
        int[] numList = [a, b];
        foreach (var rule in rules.Where(rule => numList.Contains(rule.First) && numList.Contains(rule.Second)))
        {
            result = a == rule.First ? -1 : 1;
        }

        return result;
    });

    private record Rule(int First, int Second);
}
