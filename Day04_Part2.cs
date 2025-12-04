var grid = File.ReadAllLines("input.txt").Select(l => ("." + l + ".").ToArray()).ToArray();
var pad = Enumerable.Repeat('.', grid[0].Length).ToArray();
grid = grid.Prepend(pad).Append(pad).ToArray();
var counts = new int[grid.Length, grid[0].Length];
for (int y = 1; y < grid.Length - 1; ++y)
{
    for (int x = 1; x < grid[y].Length - 1; ++x)
    {
        if (grid[y][x] == '@')
        {
            for (int yd = -1; yd <= 1; ++yd)
            {
                for (int xd = -1; xd <= 1; ++xd)
                {
                    if (!(yd == 0 && xd == 0))
                    {
                        ++counts[y + yd, x + xd];
                    }
                }
            }
        }
    }
}
int removed = 1, total = 0;
while (removed > 0)
{
    removed = 0;
    for (int y = 1; y < grid.Length - 1; ++y)
    {
        for (int x = 1; x < grid[y].Length - 1; ++x)
        {
            if (grid[y][x] == '@' && counts[y, x] < 4)
            {
                ++total;
                ++removed;
                grid[y][x] = '.';
                for (int yd = -1; yd <= 1; ++yd)
                {
                    for (int xd = -1; xd <= 1; ++xd)
                    {
                        if (!(yd == 0 && xd == 0))
                        {
                            --counts[y + yd, x + xd];
                        }
                    }
                }
            }
        }
    }
}
Console.WriteLine(total);
