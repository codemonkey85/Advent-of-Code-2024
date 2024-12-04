using System.Reflection;
using Advent2024.Days;
using AoCHelper;

namespace Advent2024.Tests;

public static class Tests
{
    private const string InputFieldName = "input";
    private const string TestInputsDir = "TestInputs";
    private const string InputsDir = "Inputs";

    [TestCase(typeof(Day01), "11", "31")]
    [TestCase(typeof(Day02), "2", "4")]
    [TestCase(typeof(Day03), "161", "")] // TODO: Need to account for different test data in part 2
    [TestCase(typeof(Day04), "", "")]
    public static async Task Test(Type type, string sol1, string sol2)
    {
        if (Activator.CreateInstance(type) is BaseDay instance)
        {
            // Gross hack to set the input data for the tests
            var testInputFilePath = Path.Combine(TestInputsDir, instance.InputFilePath).Replace(@$"\{InputsDir}\", @"\");

            Console.WriteLine($"{nameof(testInputFilePath)}: {testInputFilePath}");

            type.GetRuntimeFields()
                .FirstOrDefault(a => string.Equals(a.Name, InputFieldName))?
                .SetValue(instance, File.ReadAllText(testInputFilePath));

            await Assert.ThatAsync(async () => await instance.Solve_1(), Is.EqualTo(sol1));
            await Assert.ThatAsync(async () => await instance.Solve_2(), Is.EqualTo(sol2));
        }
        else
        {
            Assert.Fail($"{type} is not a BaseDay");
        }
    }
}
