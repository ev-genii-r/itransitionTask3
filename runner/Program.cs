using System.Security.Cryptography;
using game;
using game.com.itransition.Rudkovskii.beans;
using game.com.itransition.Rudkovskii.presentation;
using game.com.itransition.Rudkovskii.validator;
using Microsoft.VisualBasic.CompilerServices;

string[] options = args;
ValidationResult validationResult = GameLogicValidator.ValidateOptions(options);
if (validationResult.Result == false)
{
    Console.WriteLine(validationResult.Problem);
    Environment.Exit(1);
}

while (true)
{
    var HMACKey = GameLogic.GenerateHMACKey();
    var computerChoice = RandomNumberGenerator.GetInt32(options.Length);
    var HMACChoice = GameLogic.GenerateChoiceHMAC(HMACKey, options.Length, computerChoice);
    Output.ShowMenu(HMACChoice, options);
    string peopleChoice;
    int peopleChoiceInt = 0;
    while (true)
    {
        peopleChoice = Console.ReadLine();
        if (peopleChoice == "0")
        {
            break;
        }

        if (peopleChoice == "?")
        {
            Output.ShowHelp(options);
            continue;
        }

        
        try
        {
           peopleChoiceInt = int.Parse(peopleChoice);
        }
        catch (Exception e)
        {
            Console.WriteLine("input value is not valid");
            continue;
        }

        validationResult = GameLogicValidator.ValidatePeopleChoice(peopleChoiceInt, options);
        if (validationResult.Result == false)
        {
            Console.WriteLine(validationResult.Problem);
            
        }
        else
        {
            break;
        }
    }

    if (peopleChoice == "0")
    {
        break;
    }

    int result = GameLogic.FindWinner(peopleChoiceInt-1, computerChoice, options.Length);
    Output.ShowWinner(options[peopleChoiceInt-1], options[computerChoice], result);
    Console.WriteLine("HMACKey: " + HMACKey);
    Console.WriteLine();
}




