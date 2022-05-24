namespace TheSquareLife_Consoled;

internal interface IEntitiesRelationships
{
    public HashSet<Coordinate> CommonCoordinates(List<Entity> overlappingAliens);
    public HashSet<Coordinate> CommonCoordinates(Entity overlappingEntity);
    public bool OverlapWithAlien(Entity otherEntity);
}