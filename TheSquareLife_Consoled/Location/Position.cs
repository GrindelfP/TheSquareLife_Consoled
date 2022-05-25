namespace TheSquareLife_Consoled;

internal class Position
{
    internal readonly HashSet<Coordinate> Coordinates;
    private readonly Board _board;
    private Position? ShapeShifter(int horizontal, int vertical)
    {
        var newCoordinates = Coordinates.Select(it => new Coordinate(it.X + horizontal, it.Y + vertical)).ToList();
        var newCoordinatesFiltered = new HashSet<Coordinate>();
        newCoordinates.ForEach(it =>
        {
            if (it.OnBoard(_board) && (_board.TileIsEmpty(it) || Coordinates.Contains(it)))
                newCoordinatesFiltered.Add(it);
        });
        return newCoordinatesFiltered.Count == Coordinates.Count ? new Position(newCoordinatesFiltered, _board) : null;
    }
    
    internal List<Position> PossibleMoveCoordinates()
    {
        var list = new List<Position>();
        
        var moveUpPosition = ShapeShifter(0, -1);
        if (moveUpPosition != null) list.Add(moveUpPosition);
        
        var moveDownPosition = ShapeShifter(0, +1);
        if (moveDownPosition != null) list.Add(moveDownPosition);

        var moveLeftPosition = ShapeShifter(-1, 0);
        if (moveLeftPosition != null) list.Add(moveLeftPosition);

        var moveRightPosition = ShapeShifter(+1, 0);
        if (moveRightPosition != null) list.Add(moveRightPosition);

        var moveLeftUpPosition = ShapeShifter(-1, -1);
        if (moveLeftUpPosition != null) list.Add(moveLeftUpPosition);

        var moveLeftDownPosition = ShapeShifter(-1, +1);
        if (moveLeftDownPosition != null) list.Add(moveLeftDownPosition);

        var moveRightUpPosition = ShapeShifter(+1, -1);
        if (moveRightUpPosition != null) list.Add(moveRightUpPosition);

        var moveRightDownPosition = ShapeShifter(+1, +1);
        if (moveRightDownPosition != null) list.Add(moveRightDownPosition);

        return list;
    }
    
    protected internal Position(HashSet<Coordinate> coordinates, Board board)
    {
        Coordinates = coordinates;
        _board = board;
    }
}