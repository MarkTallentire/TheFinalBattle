public class Battle(Party heroes, Party monsters)
{
    private readonly Party _heroes = heroes;
    private readonly Party _monsters = monsters;
    
    public Party RunBattle()
    {
        while (true)
        {
            foreach (var party in new[] {_heroes, _monsters})
            {
                foreach (var character in party.Characters)
                {
                    if (IsDefeated(GetOpposingParty(character))) return party;
                    
                    Renderer.WriteLine($"It is {character.Name}'s turn...");
                    party.ControlledBy.ChooseAction(character, GetOpposingParty(character));
                    Renderer.WriteLine("");
                    CheckForDeadCharacters();
                }
            } 
        }
    }

    private bool IsDefeated(Party party)
    {
        return party.Characters.Count == 0;
    }

    private void CheckForDeadCharacters()
    {
        foreach (var party in new[] { _heroes, _monsters })
        {
            for (var i = 0; i < party.Characters.Count; i++)
            {
                var character = party.Characters[i];
                if (character.Health != 0) continue;


                var charactersParty = GetParty(character);
                charactersParty.RemoveCharacter(character);
            }
        }
    }

    private Party GetParty(Character character)
    {
        return _heroes.Characters.Contains(character) ? _heroes : _monsters;
    }

    private Party GetOpposingParty(Character character)
    {
        return _heroes.Characters.Contains(character) ? _monsters : _heroes;
    }
}