
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

    public Coordinate ShiftUp() => new(X, Y - 1);
    public Coordinate ShiftDown() => new(X, Y + 1);
    public Coordinate ShiftLeft() => new(X - 1, Y); 
    public Coordinate ShiftRight() => new(X + 1, Y);
    public bool OnBoard(Board board) => 0 <= X && X <= board.BoardSize.NumberOfColumns && 0 <= Y && Y <= board.BoardSize.NumberOfRows;
    
    protected internal Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}