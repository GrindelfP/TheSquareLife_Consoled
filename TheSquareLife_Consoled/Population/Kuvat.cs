using static TheSquareLife_Consoled.Colors;

namespace TheSquareLife_Consoled;

internal sealed class Kuvat : Entity
{
    internal override string Color { get; }
    internal override int Size { get; set; }
    internal Kuvat(Position position) : base(position)
    {
        Color = Green;
        Size = EntitySize.KuvatSize;
        Validate(Type, Size * Size);
    }
}