namespace AdventOfCode;

public class Day04 : BaseDay
{
    private readonly string _input;
    private int _solution1;
    private int _solution2;
    
    public Day04()
    {
        _input = File.ReadAllText(InputFilePath);
        
        var lines = _input.Split(Environment.NewLine);
        
        var bingoNumbers = lines[0].Split(',').Select(int.Parse).ToList();
        
        var boardsInput = lines[2..]
            .Select(line => line
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList()).ToList();
        
        // To make up for missing empty last row
        boardsInput.Add(new List<int>());
        
        var boards = new List<Board>();
        for (var i = 0; i < boardsInput.Count - 5; i += 6)
        {
            var rows = boardsInput.Skip(i).Take(5).ToList();
            var columns = new List<List<int>>();
            for (var j = 0; j < 5; j++)
            {
                var column = rows.Select(row => row[j]).ToList();
                columns.Add(column);
                
            }

            boards.Add(new Board(rows, columns));

        }
        
        //Part 1
        // foreach (var number in bingoNumbers)
        // {
        //     foreach (var board in boards)
        //     {
        //         board.markNumber(number);
        //         if (board.IsBingo())
        //         {
        //             var unmarkedNumbers = board.AllNumbers.Except(board.MarkedNumbers).ToList();
        //             _solution1 = unmarkedNumbers.Sum() * number;
        //             return;
        //         }
        //     }
        // }
        
        // Part 2

        var boardsWon = 0;
        var totalBoards = boards.Count;
        foreach (var number in bingoNumbers)
        {
            foreach (var board in boards)
            {
                if (board.HasWon) continue;
                
                board.markNumber(number);
                if (board.IsBingo())
                {
                    board.HasWon = true;
                    if (boardsWon == totalBoards - 1)
                    {
                        var unmarkedNumbers = board.AllNumbers.Except(board.MarkedNumbers).ToList();
                        _solution2 = unmarkedNumbers.Sum() * number;
                    } else 
                        boardsWon++;

                    
                }
            }
        }


        
    }

    public class Board(List<List<int>> rows, List<List<int>> columns)
    {
        public List<List<int>> Rows { get; } = rows;
        public List<List<int>> Columns { get; } = columns;

        public IEnumerable<int> AllNumbers => Rows.SelectMany(row => row);
        public IEnumerable<int> MarkedNumbers = [];
        public bool HasWon = false;

        public void markNumber(int number)
        {
            if (AllNumbers.Contains(number)) {
                MarkedNumbers = MarkedNumbers.Concat([number]);
            }
        }
        
        public bool IsBingo() => 
            Rows.Any(row => row.All(number => MarkedNumbers.Contains(number))) || 
            Columns.Any(column => column.All(number => MarkedNumbers.Contains(number)));
    }

    public override ValueTask<string> Solve_1() => new($"{_solution1}");

    public override ValueTask<string> Solve_2() => new($"{_solution2}");
}
