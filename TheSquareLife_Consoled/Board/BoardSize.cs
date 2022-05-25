namespace TheSquareLife_Consoled;

internal class BoardSize
{
    internal readonly int NumberOfRows;
    internal readonly int NumberOfColumns;

    protected internal BoardSize(int numberOfRows, int numberOfColumns)
    {
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
    }
}