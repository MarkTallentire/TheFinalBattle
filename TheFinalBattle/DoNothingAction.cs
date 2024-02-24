using System.ComponentModel.DataAnnotations;

public class DoNothingAction : IAction
{
    public void Do(Character character)
    {
       Renderer.WriteLine($"{character.Name.ToUpper()} does NOTHING");
    }
}