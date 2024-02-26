public class ItemAction(Character user, Character target, Party userParty, IItem itemToUse) : IAction
{
    public void Do(Character character)
    {
        Renderer.WriteLine($"{character.Name} used {itemToUse.Name}");
        
        if(userParty.Inventory.FirstOrDefault(x=>x.Name == itemToUse.Name) != null)
        {
            itemToUse.Use(character, target);
            userParty.RemoveInventoryItem(itemToUse);
        }
    }
}