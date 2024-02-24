public class Punch : IAttack
{
    public string Name { get; } = "Punch";
    public int Attack()
    {
        return 1;
    }
}