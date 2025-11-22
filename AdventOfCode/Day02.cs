namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string _input;
    private int _solution1;
    private int _solution2;
    public Day02()
    {
        
        _input = File.ReadAllText(InputFilePath);
        var lines = _input.Split(Environment.NewLine);
        var horizontalPosition = 0;
        var depth = 0;
        
        foreach (var instruction in lines)
        {
            var direction = instruction.Split(' ')[0];

            var distance = int.Parse(instruction.Split(' ')[1]);
            
            switch (direction)
            {
                case "forward":
                    horizontalPosition += distance;
                    break;
                case "down":
                    depth += distance;
                    break;
                case "up":
                    depth -= distance;
                    break;
            }
            
            _solution1 = horizontalPosition * depth;
        }
        
        //Part 2
        var aim = 0;
        horizontalPosition = 0;
        depth = 0;
        
        foreach (var instruction in lines)
        {
            var direction = instruction.Split(' ')[0];

            var distance = int.Parse(instruction.Split(' ')[1]);
            
            switch (direction)
            {
                case "forward":
                    horizontalPosition += distance;
                    depth += (aim * distance);
                    break;
                case "down":
                    aim += distance;
                    break;
                case "up":
                    aim -= distance;
                    break;
            }
            
            _solution2 = horizontalPosition * depth;
        }
        
    }

    public override ValueTask<string> Solve_1() => new($"{_solution1}");

    public override ValueTask<string> Solve_2() => new($"{_solution2}");
}
