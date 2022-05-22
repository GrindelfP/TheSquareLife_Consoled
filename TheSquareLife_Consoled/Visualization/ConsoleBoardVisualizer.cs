namespace TheSquareLife_Consoled.Visualization;

internal class ConsoleBoardVisualizer : IVisualizer
{
    private readonly Board _board;
    public void Visualize(int evolutionCycleNumber, string? extraMessage)
    {
        var message = evolutionCycleNumber == -1 ? "Evolution haven't started yet!" : $"Evolution cycle {evolutionCycleNumber + 1}";
        Console.WriteLine(message);
        Console.WriteLine(_board.ToString());
    }

    public ConsoleBoardVisualizer(Board board)
    {
        _board = board;
    }
}