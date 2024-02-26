public class Party(List<Character> characters, IPlayer player, List<IItem> startingInventory)
{
    public IPlayer ControlledBy { get; } = player;
    public List<Character> Characters { get; } = characters;

    public List<IItem> Inventory { get; } = startingInventory; 


    public void RemoveCharacter (Character character)
    {
        if (Characters.Contains(character))
            Characters.Remove(character);
    }

    public void RemoveInventoryItem(IItem item)
    {
        if (Inventory.Contains(item))
            Inventory.Remove(item);
    }
}