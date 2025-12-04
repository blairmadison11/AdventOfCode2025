var banks = File.ReadAllLines("input.txt").Select(l => l.Select(b => b - '0').ToArray()).ToArray();
long sum = 0;
foreach (var bank in banks)
{
    var batts = new int[12];
    int lastIndex = -1, endDelta = 11;
    for (int i = 0; i < 12; ++i)
    {
        lastIndex = GetLargest(bank, lastIndex + 1, bank.Length - endDelta);
        batts[i] = lastIndex;
        --endDelta;
    }
    sum += long.Parse(batts.Aggregate("", (a, c) => a + (char)(bank[c] + '0')));
}
Console.WriteLine(sum);

int GetLargest(int[] seq, int start, int end)
{
    int largest = -1, index = 0;
    for (int i = start; i < end; ++i)
    {
        if (seq[i] > largest)
        {
            largest = seq[i];
            index = i;
        }
    }
    return index;
}
