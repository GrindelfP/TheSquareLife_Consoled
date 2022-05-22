
namespace TheSquareLife_Consoled;

internal class Coordinate
{
    public readonly int X;
    public readonly int Y;

    public override bool Equals(object? obj)
    {
        var coordinate = obj as Coordinate;
        if (coordinate == null)
        {
            return false;
        }
        return X == coordinate.X && Y == coordinate.Y;
    }

    public bool OnBoard(Board board) => 0 <= X && X <= board.BoardSize.NumberOfColumns && 0 <= Y && Y <= board.BoardSize.NumberOfRows;
    
    protected internal Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}