namespace Advent2024.Days;

// https://adventofcode.com/2024/day/6
public sealed class Day06 : MyBaseDay
{
    public override string? Part1TestInput { get; set; } = """
        ....#.....
        .........#
        ..........
        ..#.......
        .......#..
        ..........
        .#..^.....
        ........#.
        #.........
        ......#...
        """;

    public Day06() => Input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        var distinctLocations = 1;
        var (map, x, y) = ParseInput();

        var xBounds = map.GetLength(1);
        var yBounds = map.GetLength(0);

        var direction = Up;

        try
        {
            while (x >= 0 && x < xBounds - 1 && y >= 0 && y < yBounds - 1)
            {
                char current;
                do
                {
                    (current, x, y) = GetNext(map, x, y, direction);

                    if (current is not '.')
                    {
                        continue;
                    }

                    distinctLocations++;
                    SetChar('X', map, x, y);
                } while (current != '#');

                // back up one step
                x -= direction.X;
                y -= direction.Y;

                // turn right
                direction = TurnRight(direction);
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        return new(distinctLocations.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new(string.Empty);
    }

    private (char[,] Map, int StartX, int StartY) ParseInput()
    {
        var lines = Input.Replace("\r", string.Empty).Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var map = new char[lines.Length, lines[0].Length];
        var startX = 0;
        var startY = 0;

        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines[y].Length; x++)
            {
                var c = lines[y][x];
                if (c is '^')
                {
                    startX = x;
                    startY = y;
                    c = 'X';
                }
                map[y, x] = c;
            }
        }

        return (map, startX, startY);
    }

    private static void SetChar(char newChar, char[,] map, int x, int y) => map[y, x] = newChar;

    private static Direction Up => new(0, -1);

    private static (char c, int newX, int newY) GetNext(char[,] map, int x, int y, Direction direction)
    {
        var newX = x + direction.X;
        var newY = y + direction.Y;
        return (map[newY, newX], newX, newY);
    }

    private static Direction TurnRight(Direction startDirection) => new(X: -startDirection.Y, Y: startDirection.X);

    private record Direction(int X, int Y);
}
