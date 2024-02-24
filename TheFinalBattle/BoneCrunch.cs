public class BoneCrunch : IAttack
{
    public string Name { get; } = "Bone Crunch";
    public int Attack()
    {
        var random = new Random();
        return random.Next(2);
    }
}