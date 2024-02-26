using TheFinalBattle.Misc;

namespace TheFinalBattle.Players;

public class Human : IPlayer
{
    public void ChooseAction(Character character, Party opposingParty, Party currentParty)
    {
        foreach (var action in character.Actions)
        {
            Menu.AddMenuItem(action.ToString());
        }
        
        Menu.AddMenuItem($"Standard Attack - {character.StandardAttack.Name}");

        if (currentParty.Inventory.Any(x => x.Name == "Health Potion"))
        {
            Menu.AddMenuItem($"Chug a Health Potion");
        }

        var option = Menu.ShowMenu();
        var chosenAction = option switch
        {
            0 => character.Actions[0],
            1 => new AttackAction(opposingParty.Characters[0], character.StandardAttack),
            2 => new ItemAction(character, character, currentParty,  currentParty.Inventory[0]),
            _ => throw new ArgumentOutOfRangeException()
        };
        
        chosenAction.Do(character);
        
    }
}