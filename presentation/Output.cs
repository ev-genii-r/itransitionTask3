namespace game.com.itransition.Rudkovskii.presentation;

public class Output
{
    public static void ShowMenu(String HMAC, String[] options)
    {
        Console.WriteLine($"HMAC: {HMAC}");
        
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine((i + 1) + $" : {options[i]}");
        }
        Console.WriteLine("0 : exit");
        Console.WriteLine("? : help");
    }

    public static void ShowHelp(string[] options)
    {
        var outcomes = new string[options.Length * options.Length];
        outcomes = FillFirstLine(outcomes, options.Length, options, FindMaxLength(options));
        outcomes = FillOutcomes(outcomes, options.Length);
        PrintOutcomes(outcomes, options.Length, options, FindMaxLength(options));
    }

    public static void ShowWinner(string peopleChoice, string computerChoice, int result)
    {
        Console.WriteLine($"your option: {peopleChoice}");
        Console.WriteLine($"computer option: {computerChoice}");
        switch (result)
        {
            case -1:
                Console.WriteLine("draw");
                break;
            case 1:
                Console.WriteLine("you win");
                break;
            case 0:
                Console.WriteLine("you loose");
                break;
        }
    }

    static int FindMaxLength(string[] options)
    {
        int maxLength = 0;
        for (int i = 0; i < options.Length; i++)
        {
            if (options[i].Length > maxLength)
            {
                maxLength = options[i].Length;
            }
        }

        return maxLength;
    }
    static string[] FillFirstLine(string[] outcomes, int length, string[] options, int maxLength)
    {
        string placesOutcomes = "";
        string placesOptions = "";
        
        for (int i = 0; i < maxLength; i++)
        {
            placesOutcomes += " ";
        }
        Console.Write(placesOutcomes + " ");
        for (int i = 0; i < length; i++)
        {
            placesOptions = "";
            for (int j = 0; j < maxLength - options[i].Length; j++)
            {
                placesOptions += " ";
            }
            Console.Write(options[i] + placesOptions + " ");
        }
        Console.WriteLine();
        
        for (int i = 0; i < length; i++)
        {
            if (i == 0)
            {
                outcomes[i] = "d" + placesOutcomes;
            }else if (i > length / 2)
            {
                outcomes[i] = "l"+ placesOutcomes;
            }
            else
            {
                outcomes[i] = "w"+ placesOutcomes;
            }
        }

        return outcomes;
    }

    static string[] FillOutcomes(string[] outcomes, int length)
    {
        for (int i = 1; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                outcomes[i * length + j] = j > 0
                    ? outcomes[(i - 1) * length + j - 1]
                    : outcomes[(i - 1) * length + length - 1];
            }
        }

        return outcomes;
    }

    static void PrintOutcomes(string[] outcomes, int length, string[] options, int maxLength)
    {
        string placesOutcomes = "";
        string placesOptions = "";
        for (int i = 0; i < maxLength; i++)
        {
            placesOutcomes += " ";
        }
        for (int i = 0; i < length; i++)
        {
            placesOptions = "";
            for (int k = 0; k < maxLength - options[i].Length; k++)
            {
                placesOptions += " ";
            }
            Console.Write(options[i] + placesOptions + " ");
            for (int j = 0; j < length; j++)
            {
                Console.Write(outcomes[i * length + j]);
            }
            Console.WriteLine();
        }
    }
}