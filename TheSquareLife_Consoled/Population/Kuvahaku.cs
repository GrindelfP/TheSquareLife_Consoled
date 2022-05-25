using static TheSquareLife_Consoled.Colors;

namespace TheSquareLife_Consoled;

internal sealed class Kuvahaku : Entity
{
    private const string Type = "Kuvahaku";
    public override string Color { get; }
    public override int Size { get; set; }
    public Kuvahaku(Position position) : base(position)
    {
        Color = Blue;
        Size = EntitySize.KuvahakuSize;
        Validate(Type, Size * Size);
    }
}