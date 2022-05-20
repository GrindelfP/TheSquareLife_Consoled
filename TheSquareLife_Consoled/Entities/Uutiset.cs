using TheSquareLife_Consoled.Constants;
using TheSquareLife_Consoled.Location;

namespace TheSquareLife_Consoled.Entities;

internal class Uutiset : Entity
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