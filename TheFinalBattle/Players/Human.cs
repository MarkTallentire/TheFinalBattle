using TheFinalBattle.Misc;

namespace TheFinalBattle.Players;

public class Human : IPlayer
{
    public void ChooseAction(Character character, Party opposingParty)
    {
        foreach (var action in character.Actions)
        {
            Menu.AddMenuItem(action.ToString());
        }
        
        Menu.AddMenuItem($"Standard Attack - {character.StandardAttack.Name}");
        var option = Menu.ShowMenu();

        var chosenAction = option switch
        {
            0 => character.Actions[0],
            1 => new AttackAction(opposingParty.Characters[0], character.StandardAttack),
            _ => throw new ArgumentOutOfRangeException()
        };
        
        chosenAction.Do(character);
        
    }
}