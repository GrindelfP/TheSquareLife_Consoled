namespace TheSquareLife_Consoled;

internal class Position
{
    public HashSet<Coordinate> Coordinates;

    public List<Coordinate> UpperCoordinates()
    {
        var min = int.MaxValue;
        foreach (var it in Coordinates)
        {
            min = it.Y < min ? it.Y : min;
        }
        var resultingCoordinates = Coordinates.Where(it => it.Y == min); 
        foreach (var it in resultingCoordinates)
        {
            it.ShiftUp();
        }

        return resultingCoordinates.ToList(); // May not work this way of converting. Further investigation required.
    }
    
    public List<Coordinate> BottomCoordinates()
    {
        var max = 0;
        foreach (var it in Coordinates)
        {
            max = it.Y > max ? it.Y : max;
        }
        var resultingCoordinates = Coordinates.Where(it => it.Y == max); 
        foreach (var it in resultingCoordinates)
        {
            it.ShiftDown();
        }

        return resultingCoordinates.ToList(); // May not work this way of converting. Further investigation required.
    }
    
    public List<Coordinate> LeftCoordinates()
    {
        var min = int.MaxValue;
        foreach (var it in Coordinates)
        {
            min = it.Y < min ? it.Y : min;
        }
        var resultingCoordinates = Coordinates.Where(it => it.Y == min); 
        foreach (var it in resultingCoordinates)
        {
            it.ShiftLeft();
        }

        return resultingCoordinates.ToList(); // May not work this way of converting. Further investigation required.
    }

    public List<Coordinate> RightCoordinates()
    {
        var max = 0;
        foreach (var it in Coordinates)
        {
            max = it.Y > max ? it.Y : max;
        }

        var resultingCoordinates = Coordinates.Where(it => it.Y == max);
        foreach (var it in resultingCoordinates)
        {
            it.ShiftRight();
        }

        return resultingCoordinates.ToList(); // May not work this way of converting. Further investigation required.
    }

    public List<Coordinate> UpperLeftCoordinates() =>
        CornerShiftCoordinates(UpperCoordinates(), LeftCoordinates(), true);
    public List<Coordinate> BottomLeftCoordinates() =>
        CornerShiftCoordinates(BottomCoordinates(), LeftCoordinates(), true);
    public List<Coordinate> UpperRightCoordinates() =>
        CornerShiftCoordinates(UpperCoordinates(), RightCoordinates(), false);
    public List<Coordinate> BottomRightCoordinates() =>
        CornerShiftCoordinates(BottomCoordinates(), RightCoordinates(), false);

    private List<Coordinate> CornerShiftCoordinates(List<Coordinate> horizontalCoordinates,
        List<Coordinate> verticalCoordinates, bool shiftLeft)
    {
        var corner = new Coordinate(verticalCoordinates[0].X, horizontalCoordinates[0].Y);
        var coordinates = new HashSet<Coordinate>();
        foreach (var horizontalCoordinate in horizontalCoordinates)
        {
            coordinates.Add(horizontalCoordinate);
        }
        coordinates.Add(corner);
        var resultingCoordinates = coordinates.ToList().OrderBy(it => it.X).ToList();
        return shiftLeft ? resultingCoordinates.GetRange(0, coordinates.Count - 1) : 
            resultingCoordinates.GetRange(1, coordinates.Count);
    }

    protected internal Position(HashSet<Coordinate> coordinates)
    {
        Coordinates = coordinates;
    }
}