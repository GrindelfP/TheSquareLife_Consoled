namespace TheSquareLife_Consoled.Visualization;

internal interface IVisualizer
{
    public void Visualize(int evolutionCycleNumber, string? extraMessage = null, int? numberOfCycles = null);
    public void Finalize(List<int> numberOfAliveEntities, Board board);
}