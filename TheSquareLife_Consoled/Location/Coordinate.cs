namespace TheSquareLife_Consoled;

internal class Coordinate
{
    internal readonly int X;
    internal readonly int Y;
    internal bool OnBoard(Board board) => 0 <= X && X <= board.BoardSize.NumberOfColumns && 0 <= Y && Y <= board.BoardSize.NumberOfRows;
    public override bool Equals(object? obj)
    {
        var coordinate = obj as Coordinate;
        if (coordinate == null)
        {
            return false;
        }
        return X == coordinate.X && Y == coordinate.Y;
    }

    public override int GetHashCode()
    {
        return new {X, Y}.GetHashCode();
    }

    protected internal Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}