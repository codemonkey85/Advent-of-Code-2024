using AoCHelper;

namespace Advent2024.Tests;

public class Day01 : Days.Day01
{
    protected override string InputFileDirPath => "TestInputs";
}

public class Day02 : Days.Day02
{
    protected override string InputFileDirPath => "TestInputs";
}

public class Day03 : Days.Day03
{
    protected override string InputFileDirPath => "TestInputs";
}

public class Day04 : Days.Day04
{
    protected override string InputFileDirPath => "TestInputs";
}

public static class Tests
{
    [TestCase(typeof(Day01), "11", "31")]
    [TestCase(typeof(Day02), "2", "4")]
    [TestCase(typeof(Day03), "161", "")]
    [TestCase(typeof(Day04), "", "")]
    public static async Task Test(Type type, string sol1, string sol2)
    {
        if (Activator.CreateInstance(type) is BaseDay instance)
        {
            await Assert.ThatAsync(async () => await instance.Solve_1(), Is.EqualTo(sol1));
            await Assert.ThatAsync(async () => await instance.Solve_2(), Is.EqualTo(sol2));
        }
        else
        {
            Assert.Fail($"{type} is not a BaseDay");
        }
    }
}
