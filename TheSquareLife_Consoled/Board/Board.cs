using static TheSquareLife_Consoled.EntitySize;
using static TheSquareLife_Consoled.BorderBlock;
using static TheSquareLife_Consoled.FieldConstants;
using static TheSquareLife_Consoled.Colors;
namespace TheSquareLife_Consoled;

internal class Board
{
    private const int Padding = 2;
    public BoardSize BoardSize { get; }
    private readonly List<Coordinate> _coordinates;
    private readonly int _numberOfRowsWithPadding;
    private readonly int _numberOfColumnsWithPadding;
    private readonly List<List<string>> _boardState;

    private List<Coordinate> InitCoordinates()
    {
        var coordinates = new List<Coordinate>();
        var rowNumberEdge = BoardSize.NumberOfRows;
        var columnNumberEdge = BoardSize.NumberOfColumns;

        var yCoordinate = BoardSize.NumberOfRows;
        var xCoordinate = BoardSize.NumberOfColumns;
        while (rowNumberEdge > 0)
        {
            while (columnNumberEdge > 0)
            {
                coordinates.Add(new Coordinate(xCoordinate + 1, yCoordinate + 1));
                xCoordinate++;
                columnNumberEdge--;
            }
            yCoordinate++;
            rowNumberEdge--;
        }

        return coordinates;
    }

    
    private List<List<string>> InitBoard()
    {
        var board = new List<List<string>>();
        var conditionOne = _numberOfRowsWithPadding;
        var conditionTwo = _numberOfColumnsWithPadding;
        var rowNumber = 0;
        var positionInRow = 0;

        while (conditionOne > 0)
        {
            while (conditionTwo > 0)
            {
                if (rowNumber == 0)
                {
                    HorizontalBorder(LeftUp, RightUp, rowNumber, positionInRow, board);
                    positionInRow++;
                    conditionTwo--;
                }

                else if (rowNumber == _numberOfRowsWithPadding - 1)
                {
                    HorizontalBorder(LeftDown, RightDown, rowNumber, positionInRow, board);
                    positionInRow++;
                    conditionTwo--;
                }

                else if (positionInRow == 0)
                {
                    board[rowNumber].Insert(positionInRow, $"{Vertical} {Gap}");
                    positionInRow++;
                    conditionTwo--;
                }

                else if (positionInRow == _numberOfColumnsWithPadding - 1)
                {
                    board[rowNumber].Insert(positionInRow, Vertical);
                    positionInRow++;
                    conditionTwo--;
                }
                
                else
                {
                    board[rowNumber].Insert(positionInRow, $"{new BoardTile()}");
                    positionInRow++;
                    conditionTwo--;
                }
            }
            rowNumber++;
            conditionOne--;
        }
        
        return board;
    }

    internal bool TileIsEmpty(Coordinate coordinates) =>
        _boardState[coordinates.Y][coordinates.X].Contains(Grey);
    
    internal void Update(List<EntityPosition> entityPositions)
    {
        // reset the Board
        _coordinates.ForEach(coordinate =>
        {
            _boardState[coordinate.Y][coordinate.X] = new Tile(Green).ToString();
        });
        
        entityPositions.ForEach(entityPosition =>
        {
            foreach (var coordinate in entityPosition.Position.Coordinates)
            {
                _boardState[coordinate.Y][coordinate.X] = new Tile(entityPosition.Color).ToString();
            }
        });
    }
    
    public override string ToString()
    {
        var _ = "";
        _boardState.ForEach(row =>
        {
            row.ForEach(element =>
            {
                _ += element;
            });
            _ += "\n";
        });
        return _;
    }

    private void HorizontalBorder(string left, string right, int rowNumber, int positionInRow, List<List<string>> board)
    {
        if (positionInRow == 0)
        {
            board[rowNumber].Insert(positionInRow, left + Horizontal);
        }
        if (positionInRow == _numberOfColumnsWithPadding - 1)
        {
            board[rowNumber].Insert(positionInRow, right);
        }
        else
        {
            board[rowNumber].Insert(positionInRow, Horizontal + Horizontal + Horizontal);    
        }
    }

    public Board(BoardSize boardSize)
    {
        BoardSize = boardSize;
        _numberOfRowsWithPadding = BoardSize.NumberOfRows + Padding;
        _coordinates = InitCoordinates();
        _numberOfColumnsWithPadding = BoardSize.NumberOfColumns + Padding;
        _boardState = InitBoard();
        if (BoardSize.NumberOfRows % MinEntityAreaSize != 0)
            throw new Exception(
                $"Number of rows must be a multiple of the minimum size of the entity area of {MinEntityAreaSize}");
        if (BoardSize.NumberOfColumns % MinEntityAreaSize != 0)
            throw new Exception(
                $"Number of columns must be a multiple of the minimum size of the entity area of {MinEntityAreaSize}");
    }
}