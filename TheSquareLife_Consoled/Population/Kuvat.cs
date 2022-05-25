using static TheSquareLife_Consoled.Colors;

namespace TheSquareLife_Consoled;

internal sealed class Kuvat : Entity
{
    private const string Type = "Kuvat";
    public override string Color { get; }
    public override int Size { get; set; }
    public Kuvat(Position position) : base(position)
    {
        Color = Green;
        Size = EntitySize.KuvahakuSize;
        Validate(Type, Size * Size);
    }
}