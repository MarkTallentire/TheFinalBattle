namespace TheFinalBattle.Misc;

public static class Menu
{
    private static List<string> _menuItem = new List<string>();


    public static void AddMenuItem(string item)
    {
        _menuItem.Add(item);
    }

    public static int ShowMenu()
    {
        for (var i = 0; i < _menuItem.Count; i++)
        {
            var item = _menuItem[i];
            Renderer.Write($"{i} - ");
            Renderer.WriteLine(item);
        }
        
        Renderer.Write("Make your choice:");
        _menuItem.Clear();
        
        return Renderer.ReadInt();
    }
}