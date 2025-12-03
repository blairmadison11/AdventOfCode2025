var ranges = File.ReadAllText("input.txt").Split(',').Select(r => { var t = r.Split('-'); return (long.Parse(t[0]), long.Parse(t[1])); }).ToArray();
long sum = 0;
foreach (var range in ranges)
{
    for (long i = range.Item1; i <= range.Item2; ++i)
    {
        var str = i.ToString();
        if (str.Length % 2 == 0 && str.Substring(0, str.Length / 2) == str.Substring(str.Length / 2))
            sum += i;
    }
}
Console.WriteLine(sum);
