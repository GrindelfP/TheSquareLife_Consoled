using static TheSquareLife_Consoled.Colors;

namespace TheSquareLife_Consoled;

internal sealed class Kuvat : Entity
{
    private const string Type = "Kuvat";
    internal override string Color { get; }
    internal override int Size { get; set; }
    internal Kuvat(Position position) : base(position)
    {
        Color = Green;
        Size = EntitySize.KuvahakuSize;
        Validate(Type, Size * Size);
    }
}