namespace TheSquareLife_Consoled;

internal abstract class Entity
{
    public Position Position { get; }
    public bool IsAlive = true;
    private Guid Id { get; }
    public abstract Color Color { get; }
    public abstract int Size { get; set; }

    protected static void Validate()
    {
        throw new NotImplementedException(); 
        // Ask how does it work and how to implement in using C#. What is 'Class<in Entity>'
    }
    public static Position Move(List<Position> positions)
    {
        var random = new Random();
        var position = positions[random.Next(0, positions.Count)];
        return position;
    }

    protected Entity(Position position)
    {
        Position = position;
        Id = Guid.NewGuid();
    }
}