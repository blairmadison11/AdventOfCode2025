using System.Text.RegularExpressions;

var numLines = new List<string>();
var nums = new List<string[]>();
var ops = new char[0];
using (var reader = new StreamReader("input.txt"))
{
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        if (!string.IsNullOrWhiteSpace(line))
        {
            if (line[0] == '+' || line[0] == '*')
            {
                ops = Regex.Matches(line, @"[\+\*]").Select(m => m.Value[0]).ToArray();
            }
            else
            {
                numLines.Add(line);
                nums.Add(Regex.Matches(line, @"\d+").Select(m => m.Value).ToArray());
            }
        }
    }
}

var colLens = new int[nums[0].Length];
for (int i = 0; i < nums[0].Length; ++i)
{
    colLens[i] = nums.Aggregate(0, (a, c) => c[i].Length > a ? c[i].Length : a);
}

var spacedNums = new List<List<string>>();
for (int i = 0; i < nums.Count; ++i)
{
    var curLine = new List<string>();
    var curPos = 0;
    for (int j = 0; j < nums[i].Length; ++j)
    {
        curLine.Add(numLines[i].Substring(curPos, colLens[j]));
        curPos += colLens[j] + 1;
    }
    spacedNums.Add(curLine);
}

ulong sum = 0;
for (int i = 0; i < nums[0].Length; ++i)
{
    var crtlnums = new List<ulong>();
    for (int j = 0; j < colLens[i]; ++j)
    {
        var numstr = "";
        for (int k = 0; k < spacedNums.Count; ++k)
        {
            var c = spacedNums[k][i][j];
            if (c != ' ')
            {
                numstr += c;
            }
        }
        crtlnums.Add(ulong.Parse(numstr));
    }

    if (ops[i] == '+')
    {
        sum += crtlnums.Aggregate((ulong)0, (a, c) => a + c);
    }
    else
    {
        sum += crtlnums.Aggregate((ulong)1, (a, c) => a * c);
    }
}
Console.WriteLine(sum);
