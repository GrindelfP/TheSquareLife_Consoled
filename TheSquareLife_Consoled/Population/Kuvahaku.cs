using static TheSquareLife_Consoled.Colors;

namespace TheSquareLife_Consoled;

internal sealed class Kuvahaku : Entity
{
    internal const string Type = "Kuvahaku";
    internal override string GType => Type;
    internal override string Color { get; }
    internal override int Size { get; set; }
    internal Kuvahaku(Position position) : base(position)
    {
        Color = Blue;
        Size = EntitySize.KuvahakuSize;
        Validate(Type, Size * Size);
    }
}