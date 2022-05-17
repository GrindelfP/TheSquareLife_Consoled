namespace TheSquareLife_Consoled.Entities;

internal abstract class Entity
{
    public Position Position { get; }
    public bool IsAlive = true;
    public Guid Id { get; }
    public abstract Color Color { get; }
    public abstract int Size { get; set; }
    public void Validate()
    {
        throw new NotImplementedException(); 
        // Ask how does it work and how to imple,ent in using C#. What is 'Class<in Entity>'
    }
    public Position Move(List<Position> positions)
    {
        var random = new Random();
        var position = positions[random.Next(0, positions.Count)];
        return position;
    }

    public Entity(Position position)
    {
        Position = position;
        Id = Guid.NewGuid();
    }
}