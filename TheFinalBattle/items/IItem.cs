public interface IItem
{
    public string Name { get; }

    public void Use(Character character, Character target);
}