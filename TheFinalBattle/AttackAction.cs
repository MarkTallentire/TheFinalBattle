public class AttackAction : IAction
{
    private readonly Character _target;
    private readonly IAttack _attack;

    public AttackAction(Character target, IAttack attack)
    {
        _target = target;
        _attack = attack;
    }

    public void Do(Character character)
    {
        var damage = _attack.Attack();
        Renderer.WriteLine($"{character.Name} used {_attack.Name} on {_target.Name}");
        _target.TakeDamage(damage);
        Renderer.WriteLine($"{_attack.Name} dealt {damage} damage to {_target.Name}");
        Renderer.WriteLine($"{_target.Name} is now at {_target.Health}/{_target.MaxHealth}");
        
    }
}