using static TheSquareLife_Consoled.EntitySize;
using static TheSquareLife_Consoled.BorderBlock;
using static TheSquareLife_Consoled.FieldConstants;
using static TheSquareLife_Consoled.Colors;

namespace TheSquareLife_Consoled;

internal class Board
{
    private const int Padding = 2;
    internal BoardSize BoardSize { get; }
    private readonly List<Coordinate> _coordinates;
    private readonly int _numberOfRowsWithPadding;
    private readonly int _numberOfColumnsWithPadding;
    internal readonly List<List<string>> _boardState;

    private List<Coordinate> InitCoordinates()
    {
        var coordinates = new List<Coordinate>();
        for (var y = 0; y < BoardSize.NumberOfRows; y++)
        {
            for (var x = 0; x < BoardSize.NumberOfColumns; x++)
            {
                coordinates.Add(new Coordinate(x + 1, y + 1));
            }
        }

        return coordinates;
    }

    
    private List<List<string>> InitBoard()
    {
        var board = new List<List<string>>();
        for (var rowNumber = 0; rowNumber < _numberOfRowsWithPadding; rowNumber++)
        {
            board.Add(new List<string>());
            for (var positionInRow = 0; positionInRow < _numberOfColumnsWithPadding; positionInRow++)
            {
                if (rowNumber == 0)
                {
                    HorizontalBorder(LeftUp, RightUp, rowNumber, positionInRow, board);
                }

                else if (rowNumber == _numberOfRowsWithPadding - 1)
                {
                    HorizontalBorder(LeftDown, RightDown, rowNumber, positionInRow, board);
                }

                else if (positionInRow == 0)
                {
                    board[rowNumber].Insert(positionInRow, $"{Vertical}{Gap}");
                }

                else if (positionInRow == _numberOfColumnsWithPadding - 1)
                {
                    board[rowNumber].Insert(positionInRow, Vertical);
                }
                
                else
                {
                    board[rowNumber].Insert(positionInRow, $"{new BoardTile()}");
                }
            }
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
            _boardState[coordinate.Y][coordinate.X] = new Tile(Grey).ToString();
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
        else if (positionInRow == _numberOfColumnsWithPadding - 1)
        {
            board[rowNumber].Insert(positionInRow, right);
        }
        else
        {
            board[rowNumber].Insert(positionInRow, Horizontal + Horizontal + Horizontal);    
        }
    }
    
    
    
    protected internal Board(BoardSize boardSize)
    {
        BoardSize = boardSize;
        _numberOfRowsWithPadding = BoardSize.NumberOfRows + Padding;
        _numberOfColumnsWithPadding = BoardSize.NumberOfColumns + Padding;
        _coordinates = InitCoordinates();
        _boardState = InitBoard();
        
        if (BoardSize.NumberOfRows % MinEntityAreaSize != 0)
            throw new Exception(
                $"Number of rows must be a multiple of the minimum size of the entity area of {MinEntityAreaSize}");
        if (BoardSize.NumberOfColumns % MinEntityAreaSize != 0)
            throw new Exception(
                $"Number of columns must be a multiple of the minimum size of the entity area of {MinEntityAreaSize}");
    }
}