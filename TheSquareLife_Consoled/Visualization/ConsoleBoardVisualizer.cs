namespace TheSquareLife_Consoled.Visualization;

internal class ConsoleBoardVisualizer : IVisualizer
{
    private readonly Board _board;
    public void Visualize(int evolutionCycleNumber, string? extraMessage)
    {
        var generalMessage = evolutionCycleNumber == -1 ? "Evolution haven't started yet!" : $"Evolution cycle #{evolutionCycleNumber + 1}";
        var message = extraMessage == null ? $"{generalMessage}" : $"{generalMessage} {extraMessage}";
        Console.WriteLine(message);
        Console.WriteLine(_board.ToString());
    }

    protected internal ConsoleBoardVisualizer(Board board)
    {
        _board = board;
    }
}