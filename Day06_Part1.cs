using System.Text.RegularExpressions;

var nums = new List<ulong[]>();
var ops = new char[0];
using (var reader = new StreamReader("input.txt"))
{
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        if (!string.IsNullOrWhiteSpace(line))
        {
            line = line.Trim();
            if (line[0] == '+' || line[0] == '*')
            {
                ops = Regex.Matches(line, @"[\+\*]").Select(m => m.Value[0]).ToArray();
            }
            else
            {
                nums.Add(Regex.Matches(line, @"\d+").Select(m => ulong.Parse(m.Value)).ToArray());
            }
        }
    }
}

ulong sum = 0;
for (int i = 0; i < nums[0].Length; ++i)
{
    var op = ops[i];
    if (op == '+')
    {
        sum += nums.Aggregate((ulong)0, (a, c) => a + c[i]);
    }
    else
    {
        sum += nums.Aggregate((ulong)1, (a, c) => a * c[i]);
    }
}
Console.WriteLine(sum);
