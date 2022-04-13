using game.com.itransition.Rudkovskii.beans;

namespace game.com.itransition.Rudkovskii.validator;

public class GameLogicValidator
{
    public static ValidationResult ValidateOptions(string[] options)
    {
        var result = new ValidationResult();
        result.Problem = "correct";
        result.Result = true;
        if (options.Length % 2 == 0)
        {
            result.Result = false;
            result.Problem = "number of options is even";
        }else if (options.Length < 3)
        {
            result.Result = false;
            result.Problem = "option should contain at least 3 item";
        }

        int concurrence;
        for (int i = 0; i < options.Length; i++)
        {
            concurrence = 0;
            for (int j = 0; j < options.Length; j++)
            {
                if (options[i] == options[j])
                {
                    concurrence += 1;
                }
            }

            if (concurrence > 1)
            {
                result.Result = false;
                result.Problem = "options should be different";
                break;
            }
        }
        return result;
    }

    public static ValidationResult ValidatePeopleChoice(int peopleChoice, string[] options)
    {
        var result = new ValidationResult();
        result.Problem = "correct";
        result.Result = true;
        if (peopleChoice > options.Length)
        {
            result.Problem = "people choisce is out of bounds";
            result.Result = false;
        }
    
        return result;
    }

}