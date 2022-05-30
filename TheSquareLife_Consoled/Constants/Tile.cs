namespace TheSquareLife_Consoled;

internal class Tile
{
    private readonly string _color;
    private const string Symbol = FieldConstants.Tile + FieldConstants.Gap;

    public override string ToString()
    {
        return $"{_color}{Symbol}{Colors.No}";
    }

    protected internal Tile(string color) {_color = color;}
}