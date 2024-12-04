using Advent2024.Days;

namespace Advent2024.Tests;

public static class Tests
{
    [TestCase(typeof(Day01), "11", "31")]
    [TestCase(typeof(Day02), "2", "4")]
    [TestCase(typeof(Day03), "161", "")]
    [TestCase(typeof(Day04), "", "")]
    public static async Task Test(Type type, string sol1, string sol2)
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
            } ?? string.Empty; ;
    }

    private enum DayParts
    {
        Part1,
        Part2
    }
}
