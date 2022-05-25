namespace TheSquareLife_Consoled.Visualization;

internal interface IVisualizer
{
    public void Visualize(int evolutionCycleNumber, string? extraMessage = null);
}