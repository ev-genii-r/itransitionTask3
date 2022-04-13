using System.Text.RegularExpressions;

namespace game.com.itransition.Rudkovskii.beans;

public class ValidationResult
{
    private bool result;
    private string problem;

    public bool Result
    {
        get => result;
        set => result = value;
    }

    public string Problem
    {
        get => problem;
        set => problem = value ?? throw new ArgumentNullException(nameof(value));
    }
}

