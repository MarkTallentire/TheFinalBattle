public class Party(List<Character> characters, IPlayer player)
{
    public IPlayer ControlledBy { get; } = player;
    public List<Character> Characters { get; } = characters;


    public void RemoveCharacter (Character character)
    {
        if (Characters.Contains(character))
            Characters.Remove(character);
    }
}