var grid = File.ReadAllLines("input.txt").Select(l => l.ToCharArray()).ToArray();
var beams = new Dictionary<int,ulong>() { { Array.IndexOf(grid[0], 'S'), 1} };
for (int i = 1; i < grid.Length; ++i)
{
    var nextBeams = new Dictionary<int,ulong>(beams);
    foreach (var beam in beams.Keys)
    {
        if (grid[i][beam] == '^')
        {
            nextBeams[beam - 1] = nextBeams.GetValueOrDefault(beam - 1) + nextBeams[beam];
            nextBeams[beam + 1] = nextBeams.GetValueOrDefault(beam + 1) + nextBeams[beam];
            nextBeams[beam] = 0;
        }
    }
    beams = nextBeams;
}
Console.WriteLine(beams.Values.Aggregate((ulong)0, (a, c) => a + c));
