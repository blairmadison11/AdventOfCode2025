var lines = File.ReadAllLines("input.txt");
var index = Array.FindIndex(lines, l => string.IsNullOrWhiteSpace(l));
var db = new Database(lines[0..index]);
Console.WriteLine(db.GetValidIdCount());

class Database
{
    private HashSet<(long start, long end)> ranges;
    public Database(string[] lines)
    {
        ranges = new HashSet<(long,long)>();
        foreach (var line in lines)
        {
            AddRange(line);
        }
    }

    public long GetValidIdCount()
    {
        long count = 0;
        foreach (var range in ranges)
        {
            count += (range.end - range.start) + 1;
        }
        return count;
    }

    private void AddRange(string line)
    {
        var nums = line.Split('-').Select(d => long.Parse(d)).ToArray();
        AddCombinedRange(GetOverlappingRanges((nums[0],nums[1])));
    }

    private HashSet<(long,long)> GetOverlappingRanges((long start, long end) newrange)
    {
        var set = new HashSet<(long,long)>() { newrange };
        foreach (var range in ranges)
        {
            if ((newrange.start >= range.start && newrange.start <= range.end + 1) ||
                (newrange.end >= range.start - 1 && newrange.end <= range.end) ||
                (range.start >= newrange.start && range.end <= newrange.end))
                set.Add(range);
        }
        return set;
    }

    private void AddCombinedRange(HashSet<(long,long)> overlapping)
    {
        var nums = overlapping.Aggregate(new List<long>(), (a, c) => {a.Add(c.Item1); a.Add(c.Item2); return a;}).ToArray();
        ranges.ExceptWith(overlapping);
        ranges.Add((nums.Min(), nums.Max()));
    }
}
