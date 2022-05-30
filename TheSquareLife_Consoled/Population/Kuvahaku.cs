using static TheSquareLife_Consoled.Colors;

namespace TheSquareLife_Consoled;

internal sealed class Kuvahaku : Entity
{
    internal override string Color { get; }
    internal override int Size { get; set; }
    internal Kuvahaku(Position position) : base(position)
    {
        Color = Blue;
        Size = EntitySize.KuvahakuSize;
        Validate(Type, Size * Size);
    }
}