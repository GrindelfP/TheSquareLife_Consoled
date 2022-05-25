namespace TheSquareLife_Consoled;

internal class Coordinate
{
    internal readonly int X;
    internal readonly int Y;
    internal bool OnBoard(Board board) => 0 <= X && X <= board.BoardSize.NumberOfColumns && 0 <= Y && Y <= board.BoardSize.NumberOfRows;
    
    protected internal Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}