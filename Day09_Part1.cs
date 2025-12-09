var coords = File.ReadAllLines("input.txt").Select(l => l.Split(',').Select(n => long.Parse(n)).ToArray()).ToArray();
long largest = 0;
for (int i = 0; i < coords.Length - 1; ++i)
{
    for (int j = i + 1; j < coords.Length; ++j)
    {
        var area = Math.Abs(coords[i][0] - coords[j][0] + 1) * Math.Abs(coords[i][1] - coords[j][1] + 1);
        if (area > largest)
        {
            largest = area;
        }
    }
}
Console.WriteLine(largest);
