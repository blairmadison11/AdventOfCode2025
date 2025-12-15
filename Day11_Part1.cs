Console.WriteLine(new Graph(File.ReadAllLines("input.txt")).GetNumPaths());

class Graph
{
    private int numNodes = 0, start = 0, end = 0;
    private Dictionary<string, int> nodeLookup = new Dictionary<string, int>();
    private Dictionary<int, HashSet<int>> connections = new Dictionary<int, HashSet<int>>();

    public Graph(string[] lines)
    {
        foreach (string line in lines)
        {
            var parts = line.Split(':');
            var start = GetNode(parts[0].Trim());
            var dests = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => GetNode(x)).ToHashSet();
            connections.Add(start, dests);
        }
    }

    public int GetNumPaths()
    {
        var numPaths = 0;
        var visited = new HashSet<int>();
        var q = new Queue<int[]>();
        q.Enqueue(new int[] { start });
        while (q.Count > 0)
        {
            var p = q.Dequeue();
            var cns = connections[p[^1]];
            foreach (var n in cns)
            {
                if (n == end)
                {
                    ++numPaths;
                }
                else if (!p.Contains(n))
                {
                    q.Enqueue(p.Append(n).ToArray());
                }
            }
        }
        return numPaths;
    }

    private int GetNode(string name)
    {
        var node = numNodes;
        if (nodeLookup.ContainsKey(name))
        {
            node = nodeLookup[name];
        }
        else
        {
            nodeLookup.Add(name, node);
            if (name == "you") start = node;
            if (name == "out") end = node;
            ++numNodes;
        }
        return node;
    }
}
