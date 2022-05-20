using TheSquareLife_Consoled.Constants;
using TheSquareLife_Consoled.Location;

namespace TheSquareLife_Consoled.Entities;

internal class Kuvat : Entity
{
    public override Color Color { get; }
    public override int Size { get; set; }
    public Kuvat(Position position) : base(position)
    {
        Color = Color.Green;
        Size = EntitySize.KuvahakuSize;
        Validate();
    }
}