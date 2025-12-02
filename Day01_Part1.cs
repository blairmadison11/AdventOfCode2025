var rotations = File.ReadAllLines("input.txt").Select(l => l[0] == 'R' ? int.Parse(l.Substring(1)) : 100 - int.Parse(l.Substring(1)));
int position = 50, password = 0;
foreach (var rotation in rotations)
{
    position = (position + rotation) % 100;
    if (position == 0) ++password;
}
Console.WriteLine(password);
