namespace TheSquareLife_Consoled;

internal class Board
{
    public BoardSize BoardSize { get; set; }

    public void Update(List<EntityPosition> entityPositions)
    {
        throw new NotImplementedException();
    }


    public Board(BoardSize boardSize)
    {
        BoardSize = boardSize;
    }
}

internal class BoardSize
{
    public readonly int NumberOfRows;
    public readonly int NumberOfColumns;

    public BoardSize(int numberOfRows, int numberOfColumns)
    {
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
    }
}