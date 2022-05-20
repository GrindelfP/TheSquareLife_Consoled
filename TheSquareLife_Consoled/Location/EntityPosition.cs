using TheSquareLife_Consoled.Constants;

namespace TheSquareLife_Consoled.Location;

internal class EntityPosition
{
    Position Position;
    Color Color;
    public EntityPosition(Position position, Color color)
    {
        Position = position;
        Color = color;
    }
}