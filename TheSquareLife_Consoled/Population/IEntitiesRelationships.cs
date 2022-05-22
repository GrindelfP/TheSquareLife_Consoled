namespace TheSquareLife_Consoled;

internal interface IEntitiesRelationships
{
    public abstract HashSet<Coordinate> CommonCoordinates(List<Entity> overlappingAliens);
    public abstract HashSet<Coordinate> CommonCoordinates(Entity overlappingEntity);
    public abstract bool OverlapWithAlien(Entity otherEntity);
}