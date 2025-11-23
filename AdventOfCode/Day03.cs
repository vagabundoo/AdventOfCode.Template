namespace AdventOfCode;

public class Day03 : BaseDay
{
    private readonly string _input;
    private int _solution1;
    private int _solution2;
    
    public Day03()
    {
        _input = File.ReadAllText(InputFilePath);
        var lines = _input.Split(Environment.NewLine);
        
        var gammaRate = "";
        var epsilonRate = "";
        for (var i = 0; i < lines[0].Length; i++)
        {
            var oneBits = lines.Count(line => line[i] == '1');
            var zeroBits = lines.Count(line => line[i] == '0');
            
            if (oneBits > zeroBits)
            {
                gammaRate += "1";
                epsilonRate += "0";
            }
            else
            {
                gammaRate += "0";
                epsilonRate += "1";
            }
        }
        
        _solution1 = Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
        
        var oxygenGeneratorRating = "";
        var co2ScrubberRating = "";
        
        var filteredLines = lines;
        for (var i = 0; i < lines[0].Length; i++)
        {
            var oneBits = filteredLines.Count(line => line[i] == '1');
            var zeroBits = filteredLines.Count(line => line[i] == '0');

            if (oneBits >= zeroBits)
                filteredLines = filteredLines.Where(line => line[i] == '1').ToArray();
            else
                filteredLines = filteredLines.Where(line => line[i] == '0').ToArray();

            if (filteredLines.Length == 1)
            {
                oxygenGeneratorRating = filteredLines[0];
                break;
            }
        }

        filteredLines = lines;
        for (var i = 0; i < lines[0].Length; i++)
        {
            var oneBits = filteredLines.Count(line => line[i] == '1');
            var zeroBits = filteredLines.Count(line => line[i] == '0');
        
            if (zeroBits <= oneBits)
                filteredLines = filteredLines.Where(line => line[i] == '0').ToArray();
            else
                filteredLines = filteredLines.Where(line => line[i] == '1').ToArray();

            if (filteredLines.Length == 1)
            {
                co2ScrubberRating = filteredLines[0];
                break;
            }
        }
        
        _solution2 = Convert.ToInt32(oxygenGeneratorRating, 2) * Convert.ToInt32(co2ScrubberRating, 2);
    }

    public override ValueTask<string> Solve_1() => new($"{_solution1}");

    public override ValueTask<string> Solve_2() => new($"{_solution2}");
}
