var grid = File.ReadAllLines("input.txt").Select(l => l.ToCharArray()).ToArray();
var beams = new HashSet<int>() { Array.IndexOf(grid[0], 'S') };
ulong splits = 0;
for (int i = 1; i < grid.Length; ++i)
{
    var nextBeams = new HashSet<int>();
    foreach (var beam in beams)
    {
        if (grid[i][beam] == '^')
        {
            nextBeams.Add(beam - 1);
            nextBeams.Add(beam + 1);
            ++splits;
        }
        else
        {
            nextBeams.Add(beam);
        }
    }
    beams = nextBeams;
}
Console.WriteLine(splits);
