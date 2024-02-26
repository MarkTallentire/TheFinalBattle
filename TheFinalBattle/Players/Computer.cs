public class Computer : IPlayer
{
    public void ChooseAction(Character character, Party opposingParty, Party currentParty)
    {
        Thread.Sleep(1000);

        if(!DecideIfUseHealthPotion(character, currentParty))
            new AttackAction(opposingParty.Characters[0], character.StandardAttack).Do(character);
    }

    private bool DecideIfUseHealthPotion(Character character, Party currentParty)
    {
        if (character.Health < character.MaxHealth / 2)
        {
            var random = new Random();
            var randomNumber = random.Next(2);
            if (randomNumber == 0)
            {
                var action = new ItemAction(character, character, currentParty, currentParty.Inventory[0]);
                action.Do(character);

                return true;
            }
        }

        return false;
    }
}