namespace Advent2024.Days;

// https://adventofcode.com/2024/day/4
// I can't lie, I asked ChatGPT for help on this one.
public sealed class Day04 : MyBaseDay
{
    public override string? Part1TestInput { get; set; } = """
        MMMSXXMASM
        MSAMXMSMSA
        AMXSXMAAMM
        MSAMASMSMX
        XMASAMXAMM
        XXAMMXXAMA
        SMSMSASXSS
        SAXAMASAAA
        MAMMMXMMMM
        MXMXAXMASX
        """;

    public Day04() => Input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        var grid = ParseInput();

        const string word = "XMAS";
        var rows = grid.Count;
        var cols = grid[0].Length;

        // Direction vectors: Right, Down, Left, Up, Diagonals
        var directions = new (int dx, int dy)[]
        {
            (0, 1),  (1, 0), (0, -1), (-1, 0),
            (1, 1),  (1, -1), (-1, 1), (-1, -1)
        };

        var count = 0;

        // Check all cells
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                // Try all directions
                foreach (var (dx, dy) in directions)
                {
                    if (CanFormWord(grid, row, col, dx, dy, word, rows, cols))
                    {
                        count++;
                    }
                }
            }
        }

        return new(count.ToString());

        static bool CanFormWord(List<string> grid, int startX, int startY, int dx, int dy, string word, int rows, int cols)
        {
            for (var i = 0; i < word.Length; i++)
            {
                var x = startX + i * dx;
                var y = startY + i * dy;

                // Check bounds
                if (x < 0 || x >= rows || y < 0 || y >= cols)
                {
                    return false;
                }

                // Check character match
                if (grid[x][y] != word[i])
                {
                    return false;
                }
            }

            return true;
        }
    }

    public override ValueTask<string> Solve_2()
    {
        var grid = ParseInput();
        var rows = grid.Count;
        var cols = grid[0].Length;

        var count = 0;

        // Iterate through each cell to check for the X-MAS pattern
        for (var row = 1; row < rows - 1; row++) // Middle row of the "X"
        {
            for (var col = 1; col < cols - 1; col++) // Middle column of the "X"
            {
                if (IsXMas(grid, row, col))
                {
                    count++;
                }
            }
        }

        return new(count.ToString());

        static bool IsXMas(List<string> grid, int centerX, int centerY)
        {
            var rows = grid.Count;
            var cols = grid[0].Length;

            // Ensure bounds
            if (centerX - 1 < 0 || centerX + 1 >= rows || centerY - 1 < 0 || centerY + 1 >= cols)
            {
                return false;
            }

            const string mas = "MAS";
            const string sam = "SAM";

            // Check the top-left and bottom-right arms
            var topLeft = $"{grid[centerX - 1][centerY - 1]}{grid[centerX][centerY]}{grid[centerX + 1][centerY + 1]}";
            var bottomRight = $"{grid[centerX + 1][centerY - 1]}{grid[centerX][centerY]}{grid[centerX - 1][centerY + 1]}";

            return topLeft is mas or sam &&
                   bottomRight is mas or sam;
        }
    }

    private List<string> ParseInput() => Input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                                              .Select(line => line.Replace("\r", string.Empty))
                                              .ToList();
}
