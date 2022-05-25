using static TheSquareLife_Consoled.Colors;
namespace TheSquareLife_Consoled;

internal sealed class Uutiset : Entity
{
    private const string Type = "Uutiset";
    public override string Color { get; }
    public override int Size { get; set; }
    public Uutiset(Position position) : base(position)
    {
        Color = Red;
        Size = EntitySize.KuvahakuSize;
        Validate(Type, Size * Size);
    }
}