namespace TheSquareLife_Consoled;

internal abstract partial class Entity
{
    internal Position Position { get; private set; }
    internal bool IsAlive = true;
    private Guid Id { get; }
    internal abstract string Color { get; }
    internal abstract int Size { get; set; }

    protected void Validate(string entityType, int area)
    {
        if (Position.Coordinates.Count != area) 
            throw new ArgumentException($"{entityType} must occupy {area} coordinates, number of supplied coordinates is {Position.Coordinates.Count}");
    }
    internal void Move()
    {
        var positions = Position.PossibleMoveCoordinates();
        var randomElementIndex = new Random().Next(0, positions.Count);
        Position = positions[randomElementIndex];
    }
    
    protected internal Entity(Position position)
    {
        Position = position;
        Id = Guid.NewGuid();
    }
}