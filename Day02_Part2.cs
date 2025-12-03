using System.Text.RegularExpressions;
var ranges = File.ReadAllText("input.txt").Split(',').Select(r => { var t = r.Split('-'); return (long.Parse(t[0]), long.Parse(t[1])); }).ToArray();
long sum = 0;
foreach (var range in ranges)
{
    for (long i = range.Item1; i <= range.Item2; ++i)
    {
        var str = i.ToString();
        for (int j = 0; j <= str.Length / 2; ++j)
        {
            if (Regex.IsMatch(str.Substring(j), string.Format("^({0})+$", str.Substring(0, j))))
            {
                sum += i;
                break;
            }
        }
    }
}
Console.WriteLine(sum);
