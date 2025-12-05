var lines = File.ReadAllLines("input.txt");
var index = Array.FindIndex(lines, l => string.IsNullOrWhiteSpace(l));
var ids = lines[(index + 1)..lines.Length].Select(l => long.Parse(l)).ToArray();
var db = new Database(lines[0..index]);
var sum = ids.Aggregate((long)0, (a, c) => a + (db.IsInRange(c)? 1 : 0));
Console.WriteLine(sum);

class Database
{
    private List<(long start, long end)> ranges;
    public Database(string[] lines)
    {
        ranges = new List<(long,long)>();
        foreach (var line in lines)
        {
            AddRange(line);
        }
    }

    public bool IsInRange(long id)
    {
        foreach (var range in ranges)
        {
            if (id >= range.start && id <= range.end)
                return true;
        }
        return false;
    }

    private void AddRange(string line)
    {
        var nums = line.Split('-').Select(d => long.Parse(d)).ToArray();
        var start = GetRange(nums[0]);
        var end = GetRange(nums[1]);
        var overlapping = new List<(long,long)>();
        if (start != null) overlapping.Add(((long, long))start);
        if (end != null) overlapping.Add(((long, long))end);
        overlapping.Add((nums[0],nums[1]));
        AddCombinedRange(overlapping);
    }

    private (long,long)? GetRange(long num)
    {
        foreach (var range in ranges)
        {
            if (num >= range.start && num <= range.end)
                return range;
        }
        return null;
    }

    private void AddCombinedRange(List<(long,long)> overlapping)
    {
        var nums = overlapping.Aggregate(new List<long>(), (a, c) => {a.Add(c.Item1); a.Add(c.Item2); return a;}).ToArray();
        foreach(var range in overlapping)
        {
            ranges.Remove(range);
        }
        ranges.Add((nums.Min(), nums.Max()));
    }

    public void PrintRanges()
    {
        foreach(var range in ranges)
        {
            Console.WriteLine(range.ToString());
        }
    }
}
