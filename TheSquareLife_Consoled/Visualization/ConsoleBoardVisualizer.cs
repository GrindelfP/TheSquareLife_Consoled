namespace TheSquareLife_Consoled.Visualization;

internal class ConsoleBoardVisualizer : BoardVisualizer
{
    public override void Visualize(int evolutionCycleNumber)
    {
        var message = evolutionCycleNumber == -1 ? "Evolution haven't started yet!" : $"Evolution cycle {evolutionCycleNumber + 1}";
        Console.WriteLine(message);
        //Console.WriteLine(Board.ToString());
    }
}