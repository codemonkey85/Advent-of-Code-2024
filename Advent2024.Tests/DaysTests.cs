using System.Reflection;
using Advent2024.Days;
using AoCHelper;

namespace Advent2024.Tests;

public static class Tests
{
    [TestCase(typeof(Day01), "11", "31")]
    [TestCase(typeof(Day02), "2", "4")]
    [TestCase(typeof(Day03), "161", "")] // TODO: Need to account for different test data in part 2
    [TestCase(typeof(Day04), "", "")]
    public static async Task Test(Type type, string sol1, string sol2)
    {
        const string InputFieldName = "input";

        if (Activator.CreateInstance(type) is BaseDay instance)
        {
            // Gross hack to set the input data for the tests
            type.GetRuntimeFields()
                .FirstOrDefault(a => string.Equals(a.Name, InputFieldName))?
                .SetValue(instance, File.ReadAllText(ResolveTestInputPath(instance.InputFilePath)));

            await Assert.ThatAsync(async () => await instance.Solve_1(), Is.EqualTo(sol1));
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
    }
}
