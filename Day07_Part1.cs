var grid = File.ReadAllLines("input.txt").Select(l => l.ToCharArray()).ToArray();
var beams = new HashSet<int>() { Array.IndexOf(grid[0], 'S') };
var lastpos = grid[0].Length - 1;
long splits = 0;
for (int i = 1; i < grid.Length; ++i)
{
    var newBeams = new HashSet<int>();
    foreach (var beam in beams)
    {
        if (grid[i][beam] == '^')
        {
            if (beam > 0) newBeams.Add(beam - 1);
            if (beam < lastpos) newBeams.Add(beam + 1);
            ++splits;
        }
        else
        {
            newBeams.Add(beam);
        }
    }
    beams = newBeams;
}
Console.WriteLine(splits);
