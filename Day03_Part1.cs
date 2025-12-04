var banks = File.ReadAllLines("input.txt").Select(l => l.Select(b => b - '0').ToArray()).ToArray();
long sum = 0;
foreach (var bank in banks)
{
    var first = GetLargest(bank, 0, bank.Length - 1);
    var second = GetLargest(bank, first + 1, bank.Length);
    sum += (bank[first] * 10) + bank[second];
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
