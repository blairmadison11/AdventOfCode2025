var junctions = File.ReadAllLines("input.txt").Select(l => l.Split(',').Select(c => double.Parse(c)).ToArray()).ToArray();
var circuits = Enumerable.Range(0, junctions.Length).ToDictionary(i => i, i => new HashSet<int>() { i });
var distances = new PriorityQueue<(int x, int y), double>();
var GetDistance = (double[] c1, double[] c2) => Math.Sqrt(Math.Pow(c2[0] - c1[0], 2) + Math.Pow(c2[1] - c1[1], 2) + Math.Pow(c2[2] - c1[2], 2));

for (int i = 0; i < junctions.Length - 1; ++i)
{
    for (int j = i + 1; j < junctions.Length; ++j)
    {
        distances.Enqueue((i, j), GetDistance(junctions[i], junctions[j]));
    }
}

(int x, int y) last = (0, 0);
while (circuits.Values.Distinct().Count() > 1)
{
    last = distances.Dequeue();
    if (circuits[last.x] != circuits[last.y])
    {
        var joined = new HashSet<int>(circuits[last.x].Union(circuits[last.y]));
        foreach (var index in joined)
        {
            circuits[index] = joined;
        }
    }
}

Console.WriteLine(junctions[last.x][0] * junctions[last.y][0]);
