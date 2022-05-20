using TheSquareLife_Consoled.Location;

namespace TheSquareLife_Consoled.MainUtility;

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
    public static int NumberOfRows;
    public static int NumberOfColumns;

    public BoardSize(int numberOfRows, int numberOfColumns)
    {
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
    }
}