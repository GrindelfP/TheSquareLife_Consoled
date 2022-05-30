namespace TheSquareLife_Consoled;

internal struct EntitySize
{
    internal const int KuvahakuSize = 1;
    internal const int KuvatSize = 2;
    internal const int UutisetSize = 3;
    // We put entities originally in slots of 5x5 to ensure that they are wrapped in a border of minimum 1 empty tile  
    internal const int MinEntityAreaSideSize = UutisetSize + 2;
}