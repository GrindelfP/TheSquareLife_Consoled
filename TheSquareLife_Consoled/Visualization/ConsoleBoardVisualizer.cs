namespace TheSquareLife_Consoled.Visualization;

internal class ConsoleBoardVisualizer : IVisualizer
{
    private readonly Board _board;
    public void Visualize(int evolutionCycleNumber, string? extraMessage, int? numberOfCycles)
    {
        var generalMessage = evolutionCycleNumber == -1 ? "Evolution haven't started yet! The following board is an initial state of the system:" : $"Evolution cycle #{evolutionCycleNumber + 1}:";
        var message = extraMessage == null ? $"{generalMessage}" : $"{generalMessage} {extraMessage}";
        Console.WriteLine(message);
        Console.WriteLine(_board.ToString());
    }

    public void Finalize(List<int> numberOfAliveEntities, Board board)
    {
        const string finite = "Evolution ends here. The survivors are: \n\n";
        var uutisetDepiction = "";
        
        if (numberOfAliveEntities[2] != 0)
        {
            var uutisetTile = new Tile(Colors.Red).ToString();
            for (var row = 0; row < 3; row++)
            {
                for (var column = 0; column < 3; column++)
                {
                    uutisetDepiction += uutisetTile;
                }

                uutisetDepiction += row == 1 ? $"{numberOfAliveEntities[2]} Uutiset survived to the end." : "";
                uutisetDepiction += row == 2 ? "\n\n" : "\n";
            } 
        }

        var kuvahakuDepiction = "";
        if (numberOfAliveEntities[0] != 0)
        {
            var kuvahakuTile = new Tile(Colors.Blue).ToString();
            kuvahakuDepiction = "      " + kuvahakuTile + $"{numberOfAliveEntities[0]} species of Kuvahaku survived to the end.\n\n";
        }

        var kuvatDepiction = "";
        if (numberOfAliveEntities[1] != 0)
        {
            var kuvatTile = new Tile(Colors.Green).ToString();
            kuvatDepiction = "";
            for (var row = 0; row < 2; row++)
            {
                kuvatDepiction += "   ";
                for (var column = 0; column < 2; column++)
                {
                    kuvatDepiction += kuvatTile;
                }
                kuvatDepiction += row == 1 ? "" : "\n";
            }
            kuvatDepiction += $"{numberOfAliveEntities[1]} species of Kuvat survived to the end.\n";
        }

        
        Console.WriteLine("============================================\n" + finite + uutisetDepiction + kuvahakuDepiction + kuvatDepiction);
    }

    protected internal ConsoleBoardVisualizer(Board board)
    {
        _board = board;
    }
}