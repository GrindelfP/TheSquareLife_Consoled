namespace TheSquareLife_Consoled;

internal abstract partial class Entity
{
    public Position Position { get; private set; }
    public bool IsAlive = true;
    private Guid Id { get; }
    public abstract Color Color { get; }
    public abstract int Size { get; set; }

    protected static void Validate()
    {
        throw new NotImplementedException(); 
        // Ask how does it work and how to implement in using C#. What is 'Class<in Entity>'
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