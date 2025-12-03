var rotations = File.ReadAllLines("input.txt").Select(l => l[0] == 'R' ? int.Parse(l.Substring(1)) : -int.Parse(l.Substring(1)));
int position = 50, password = 0;
foreach (var rotation in rotations)
{
    int normalizedrotation = rotation;
    if(rotation <= -100)
    {
        password += rotation / -100;
        normalizedrotation %= -100;
    }
    else if (rotation >= 100)
    {
        password += rotation / 100;
        normalizedrotation %= 100;
    }
    position += normalizedrotation;
    if ((position <= 0 && position != normalizedrotation) || position >= 100) ++password;
    position = (position + 100) % 100;
}
Console.WriteLine(password);
