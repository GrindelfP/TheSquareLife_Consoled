namespace TheSquareLife_Consoled.Entities;

internal class Kuvahaku : Entity
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