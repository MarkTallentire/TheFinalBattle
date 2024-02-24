public class Unravel : IAttack
{
    public string Name { get; } = "Unravel";
    public int Attack()
    {
        var random = new Random();
        return random.Next(2);
        
    }
}