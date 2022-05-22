namespace TheSquareLife_Consoled;

internal abstract partial class Entity : IEntitiesRelationships
{
    public HashSet<Coordinate> CommonCoordinates(List<Entity> overlappingAliens)
    {
        var alienCoordinates = overlappingAliens.SelectMany(it => it.Position.Coordinates);
        return Position.Coordinates.Intersect(alienCoordinates).ToHashSet();
    }
    public HashSet<Coordinate> CommonCoordinates(Entity overlappingEntity) 
        => Position.Coordinates.Intersect(overlappingEntity.Position.Coordinates).ToHashSet();
    public bool OverlapWithAlien(Entity otherEntity) // FLAG: may not work because of type comparison
    {
        return GetType() != otherEntity.GetType() && CommonCoordinates(otherEntity).Count != 0;
    }
}