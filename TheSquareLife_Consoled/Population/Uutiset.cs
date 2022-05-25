using static TheSquareLife_Consoled.Colors;
namespace TheSquareLife_Consoled;

internal sealed class Uutiset : Entity
{
    private const string Type = "Uutiset";
    internal override string Color { get; }
    internal override int Size { get; set; }

    internal Uutiset(Position position) : base(position)
    {
        Color = Red;
        Size = EntitySize.KuvahakuSize;
        Validate(Type, Size * Size);
    }
}