using System.Text.RegularExpressions;
Console.WriteLine(File.ReadAllLines("input.txt").Select(l => new Machine(l).GetFewestPresses()).Sum());

class Machine
{
    private uint lights;
    private uint[] buttons;
    private HashSet<uint> visited = new HashSet<uint>();

    public Machine(string data)
    {
        var lightStr = new string(Regex.Match(data, @"\[([\.\#]+)\]").Groups[1].Value.Select(c => c == '#' ? '1' : '0').ToArray());
        lights = Convert.ToUInt32(lightStr, 2);
        buttons = Regex.Matches(data, @"\(([\d,]+)\)").Select(m => m.Groups[1].Value.Split(',').Aggregate((uint)0, (a, d) => a | (uint)(1 << (lightStr.Length - int.Parse(d) - 1)))).ToArray();
    }

    public int GetFewestPresses() => GetFewestPresses(new Queue<(int, uint)>(new [] { (0, (uint)0) }));

    private int GetFewestPresses(Queue<(int presses, uint lights)> states)
    {
        var solution = -1;
        while (solution == -1)
        {
            var state = states.Dequeue();
            foreach (var button in buttons)
            {
                var nextLights = state.lights ^ button;
                if (lights == nextLights)
                {
                    solution = state.presses + 1;
                    break;
                }
                if (!visited.Contains(nextLights))
                {
                    visited.Add(nextLights);
                    states.Enqueue((state.presses + 1, nextLights));
                }
            }
        }
        return solution;
    }
}
    
