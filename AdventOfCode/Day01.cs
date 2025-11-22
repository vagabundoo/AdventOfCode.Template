namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;
    private int _solution1;
    private int _solution2;
    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
        var lines = _input.Split(Environment.NewLine);
        
        var count = 0;
        for (var i = 0; i < lines.Length - 1; i++)
            if (int.Parse(lines[i]) < int.Parse(lines[i + 1]))
                count++;
        _solution1 = count;

        count = 0;
        for (var i = 0; i < lines.Length - 3; i++)
        {
            var currentWindowSum = int.Parse(lines[i]) + int.Parse(lines[i + 1]) + int.Parse(lines[i + 2]);
            var nextWindowSum = int.Parse(lines[i + 1]) + int.Parse(lines[i + 2]) + int.Parse(lines[i + 3]);
            if (currentWindowSum < nextWindowSum)
                count++;
        }

        _solution2 = count; 
    }

    public override ValueTask<string> Solve_1() => new($"{_solution1}");

    public override ValueTask<string> Solve_2() => new($"{_solution2}");
}
