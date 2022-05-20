namespace TheSquareLife_Consoled;

internal class Position
{
    public HashSet<Coordinate> Coordinates;

    public List<Coordinate> UpperCoordinates()
    {
        var min = int.MaxValue;
        Coordinates.ForEach(it =>
        {
            min = it.Y < min ? it.Y : min;
        });
        var resultingCoordinates = Coordinates.Where(it => it.Y == min); 
        foreach (var resultingCoordinate in resultingCoordinates)
        {
            resultingCoordinate.ShiftUp();
        }

        return (List<Coordinate>)resultingCoordinates; // May not work this way. Further investigation required.
    }
    
    protected internal Position(HashSet<Coordinate> coordinates)
    {
        Coordinates = coordinates;
    }
}
