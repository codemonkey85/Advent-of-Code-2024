using Advent2024.Days;

namespace Advent2024.Tests;

public static class Tests
{
    [TestCase(typeof(Day01), "11", "31")]
    public static async Task Day1Test(Type type, string sol1, string sol2) => await TestInternal(type, sol1, sol2);

    [TestCase(typeof(Day02), "2", "4")]
    public static async Task Day2Test(Type type, string sol1, string sol2) => await TestInternal(type, sol1, sol2);

    [TestCase(typeof(Day03), "161", "48")]
    public static async Task Day3Test(Type type, string sol1, string sol2) => await TestInternal(type, sol1, sol2);

    [TestCase(typeof(Day04), "18", "9")]
    public static async Task Day4Test(Type type, string sol1, string sol2) => await TestInternal(type, sol1, sol2);

    [TestCase(typeof(Day05), "143", "")]
    public static async Task Day5Test(Type type, string sol1, string sol2) => await TestInternal(type, sol1, sol2);

    private static async Task TestInternal(Type type, string sol1, string sol2)
    {
        if (Activator.CreateInstance(type) is MyBaseDay instance)
        {
            OverrideMyBaseDayInput(instance, DayParts.Part1);
            await Assert.ThatAsync(async () => await instance.Solve_1(), Is.EqualTo(sol1));

            OverrideMyBaseDayInput(instance, DayParts.Part2);
            await Assert.ThatAsync(async () => await instance.Solve_2(), Is.EqualTo(sol2));
        }
        else
        {
            Assert.Fail($"{type} is not a BaseDay");
        }

        static void OverrideMyBaseDayInput(MyBaseDay instance, DayParts part) =>
            instance.Input = part switch
            {
                DayParts.Part1 => instance.Part1TestInput,
                DayParts.Part2 => instance.Part2TestInput ?? instance.Part1TestInput,
                _ => throw new ArgumentOutOfRangeException(nameof(part))
            } ?? string.Empty;
    }

    private enum DayParts
    {
        Part1,
        Part2
    }
}
