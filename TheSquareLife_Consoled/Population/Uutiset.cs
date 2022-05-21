namespace TheSquareLife_Consoled;

internal sealed class Uutiset : Entity
{
    public override Color Color { get; }
    public override int Size { get; set; }
    public Uutiset(Position position) : base(position)
    {
        Color = Color.Red;
        Size = EntitySize.KuvahakuSize;
        Validate();
    }
}