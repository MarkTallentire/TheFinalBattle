public class HealthPotion: IItem
{
    public string Name { get; } = "Health Potion";
    
    private readonly int _healthAmount = 10;
    
    public void Use(Character character, Character target)
    {
        target.Heal(_healthAmount);
    }
}