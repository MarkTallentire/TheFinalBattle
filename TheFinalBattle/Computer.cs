public class Computer : IPlayer
{
    public void ChooseAction(Character character, Party opposingParty)
    {
        Thread.Sleep(1000);
        new AttackAction(opposingParty.Characters[0], character.StandardAttack).Do(character);
    }

    
}