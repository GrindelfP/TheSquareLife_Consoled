namespace TheSquareLife_Consoled;

internal sealed class Kuvahaku : Entity
{
    public override Color Color { get; }
    public override int Size { get; set; }
    public Kuvahaku(Position position) : base(position)
    {
        Color = Color.Blue;
        Size = EntitySize.KuvahakuSize;
        Validate();
    }
}