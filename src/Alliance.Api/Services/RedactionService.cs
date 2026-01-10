using Alliance.Api.Infrastructure.Configuration;
using System.Text;

namespace Alliance.Api.Services;

public class RedactionService(RedactionConfiguration configuration) : IRedactionService
{
    private readonly HashSet<string> _keywordSet = configuration.Keywords.ToHashSet(StringComparer.OrdinalIgnoreCase);
    
    public string Redact(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var output = new StringBuilder(input.Length);
        var unigramStart = -1;

        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];
            var isWordChar = IsWordCharacter(c);

            // If c is a word character, and we're not currently tracking a unigram, we start tracking oneit
            if (isWordChar && unigramStart < 0) 
                unigramStart = i;

            // If it's a word character, we just keep iterating through the string
            if (isWordChar)
                continue;
            
            // If we reach this point, we're not looking at a word character.  If we were tracking a unigram, we should
            // extract that value and compare it against the keyword set. 
            if (unigramStart >= 0)
            {
                var word = input.AsSpan(unigramStart, i - unigramStart).ToString();
                AppendWord(output, word);
                unigramStart = -1;
            }

            output.Append(c);
        }

        // If we were tracking a unigram when we reached the end of the string, we'll check that for redaction too
        if(unigramStart >= 0)
            AppendWord(output, input.AsSpan(unigramStart).ToString());
        
        return output.ToString();
    }

    private static bool IsWordCharacter(char c)
        => char.IsLetter(c);

    private void AppendWord(StringBuilder sb, string word) 
        => sb.Append(_keywordSet.Contains(word) ? configuration.Notice : word);
    
}