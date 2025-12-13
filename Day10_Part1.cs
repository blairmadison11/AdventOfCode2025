using System.Text.RegularExpressions;
Console.WriteLine(File.ReadAllLines("input.txt").Select(l => new Machine(l).GetFewestPresses()).Sum());

class Machine
{
    private bool[] lights;
    private HashSet<int>[] buttons;
    private HashSet<bool[]> visited = new HashSet<bool[]>();

    public Machine(string data)
    {
        lights = Regex.Match(data, @"\[([\.\#]+)\]").Groups[1].Value.Select(c => c == '#').ToArray();
        buttons = Regex.Matches(data, @"\(([\d,]+)\)").Select(m => m.Groups[1].Value.Split(',').Select(d => int.Parse(d)).ToHashSet()).ToArray();
    }

    public int GetFewestPresses() => GetFewestPresses(new Queue<(int presses, bool[] lights)>(new [] { (0, new bool[lights.Length]) }));

    private int GetFewestPresses(Queue<(int presses, bool[] lights)> states)
    {
        var solution = -1;
        while (solution == -1)
        {
            var state = states.Dequeue();
            for (int i = 0; i < buttons.Length && solution == -1; ++i)
            {
                var nextLights = state.lights.Select((b, k) => buttons[i].Contains(k) ? !b : b).ToArray();
                if (lights.SequenceEqual(nextLights))
                {
                    solution = state.presses + 1;
                }
                else if (!visited.Contains(nextLights))
                {
                    visited.Add(nextLights);
                    states.Enqueue((state.presses + 1, nextLights));
                }
            }
        }
        return solution;
    }
}
    
