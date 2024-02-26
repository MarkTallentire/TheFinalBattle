public class Character
{
    public string Name { get; }
    public List<IAction> Actions { get; }
    public IAttack StandardAttack { get; }

    public int MaxHealth { get; }
    public int Health { get; private set; }

    protected Character(string name, IAttack standardAttack, int maxHealth)
    {
        Name = name;
        Actions = new List<IAction>() { new DoNothingAction() };
        StandardAttack = standardAttack;
        
        MaxHealth = maxHealth;
        Health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (Health - damage >= 0)
            Health -= damage;
    }

    public void Heal(int amount)
    {
        Health += amount;
    }
    
}