namespace TheSquareLife_Consoled;

internal abstract partial class Entity
{
    public Position Position { get; private set; }
    public bool IsAlive = true;
    private Guid Id { get; }
    public abstract string Color { get; }
    public abstract int Size { get; set; }

    protected void Validate(string entityType, int area)
    {
        if (Position.Coordinates.Count != area) 
            throw new ArgumentException($"{entityType} must occupy {area} coordinates, number of supplied coordinates is {Position.Coordinates.Count}");
    }
    public void Move()
    {
        var positions = Position.PossibleMoveCoordinates();
        var randomElementIndex = new Random().Next(0, positions.Count);
        Position = positions[randomElementIndex];
    }
    
    protected Entity(Position position)
    {
        Position = position;
        Id = Guid.NewGuid();
    }
}