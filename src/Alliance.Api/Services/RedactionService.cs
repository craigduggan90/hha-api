using System.Text;

namespace Alliance.Api.Services;

public class RedactionService : IRedactionService
{
    private const string RedactionText = "REDACTED";

    private readonly string[] RedactWords =
    [
        "Dog",
        "Cat",
        "Snake",
        "Dolphin",
        "Mammal"
    ];

    public string Redact(string input)
    {
        // Single iteration over a string

        var response = new StringBuilder();

        int pointer = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var current = input[i];

            if (!char.IsLetter(current))
                return input;

        }
        
        return input;
    }
    
    
    
    private static bool IsWordCharacter(string s, int index)
    {
        return false;
    }
    
    private bool IsBanned(string word) 
        => RedactWords.Any(banned => word.Equals(banned, StringComparison.OrdinalIgnoreCase));
}