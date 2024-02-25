public static class Renderer
{
    public static void WriteLine(string text)
    {
        Console.WriteLine(text);
    }

    public static void Write(string text)
    {
        Console.Write(text);
    }

    public static void Write(char text)
    {
        Console.Write(text);
    }

    public static void Write(string text, JustifyOptions option)
    {
        IJustify justify = option switch
        {
            JustifyOptions.Right => new JustifyRight(),
            JustifyOptions.Center => new JustifyCenter(),
            JustifyOptions.Left => new JustifyLeft(),
            _ => throw new ArgumentOutOfRangeException(nameof(option), option, null)
        };
        
        justify.JustifyText(text, Write);
    }
    

    public static void FillLine(char characterToFill, string centralText = "")
    {
        var lineToWrite = new List<Char>();
        while (lineToWrite.Count <= Console.WindowWidth - 1)
        {
            lineToWrite.Add(characterToFill);
        }

        InjectIntoCenter(centralText, lineToWrite);

        foreach (var c in lineToWrite)
        {
            Write(c);
        }
    }

    private static void InjectIntoCenter(string centralText, List<char> lineToWrite)
    {
        if (!string.IsNullOrEmpty(centralText))
        {
            var centerPoint = lineToWrite.Count / 2;
            var halfWord = centralText.Length / 2;

            for (int i = 0; i < halfWord; i++)
            {
                lineToWrite[centerPoint - i] = centralText[halfWord - 1 - i];
                lineToWrite[centerPoint + 1 + i] = centralText[halfWord + i];
            }
        }
    }

    public static int ReadInt()
    {
        int result;

        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Write("I don't have time for this mortal, pick something: ");
            Console.ReadLine();
        }

        return result;
    }
}

public class JustifyLeft : IJustify
{
    public void JustifyText(string text, Action<string> write)
    {
        write(text);
    }
}

public class JustifyRight : IJustify
{
    public void JustifyText(string text, Action<string> write)
    {
        Console.SetCursorPosition(Console.WindowWidth - text.Length, Console.GetCursorPosition().Top);
        write(text);
    }
}

public class JustifyCenter : IJustify
{
    public void JustifyText(string text, Action<string> write)
    {
        Console.SetCursorPosition(Console.WindowWidth /2 - text.Length /2, Console.GetCursorPosition().Top);
        write(text);
    }
}

public interface IJustify
{
    public void JustifyText(string text, Action<string> write);
}

public enum JustifyOptions
{
    Right,
    Center,
    Left
}