namespace TheSquareLife_Consoled.Entities;

internal class Uutiset : Entity
{
    public override Color Color { get; }
    public override int Size { get; set; }
    public Uutiset(Position position) : base(position)
    {
        Size = EntitySize.KuvahakuSize;
        Validate();
    }
}