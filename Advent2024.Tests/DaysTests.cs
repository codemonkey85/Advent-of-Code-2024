using Advent2024.Days;
using AoCHelper;

namespace Advent2024.Tests;

public static class Tests
{
    private const string Day03Part2TestInput = @"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

    [TestCase(typeof(Day01), "11", "31")]
    [TestCase(typeof(Day02), "2", "4")]
    [TestCase(typeof(Day03), "161", "48", Day03Part2TestInput)]
    [TestCase(typeof(Day04), "18", "")]
    public static async Task Test(Type type, string sol1, string sol2, string? test2InputOverride = null)
    {
        if (Activator.CreateInstance(type) is BaseDay instance)
        {
            OverrideMyBaseDayInput(instance, File.ReadAllText(ResolveTestInputPath(instance.InputFilePath)));

            await Assert.ThatAsync(async () => await instance.Solve_1(), Is.EqualTo(sol1));

            if (test2InputOverride != null)
            {
                OverrideMyBaseDayInput(instance, test2InputOverride);
            }
            await Assert.ThatAsync(async () => await instance.Solve_2(), Is.EqualTo(sol2));
        }
        else
        {
            Assert.Fail($"{type} is not a BaseDay");
        }

        static string ResolveTestInputPath(string inputFilePath)
        {
            const string TestInputsDir = "TestInputs";
            const string InputsDir = "Inputs";

            // Ensure cross-platform compatibility by resolving the path and removing unnecessary parts
            return Path.GetFullPath(Path.Combine(TestInputsDir, inputFilePath))
                .Replace($"{Path.DirectorySeparatorChar}{InputsDir}{Path.DirectorySeparatorChar}", $"{Path.DirectorySeparatorChar}")
                .Replace($"{Path.AltDirectorySeparatorChar}{InputsDir}{Path.AltDirectorySeparatorChar}", $"{Path.AltDirectorySeparatorChar}");
        }

        static void OverrideMyBaseDayInput(object? instance, string input) 
        {
            if (instance is MyBaseDay myBaseDay)
            {
                myBaseDay.Input = input;
            }
        }
    }
}
