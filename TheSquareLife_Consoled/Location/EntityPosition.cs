namespace TheSquareLife_Consoled;

internal class EntityPosition
{
    internal readonly Position Position;
    internal readonly string Color;
    protected internal EntityPosition(Position position, string color)
    {
        Position = position;
        Color = color;
    }
}