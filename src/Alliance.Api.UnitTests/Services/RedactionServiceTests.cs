using Alliance.Api.Infrastructure.Configuration;
using Alliance.Api.Services;

namespace Alliance.Api.UnitTests.Services;

public class RedactionServiceTests
{
    private static readonly RedactionConfiguration Config = new()
    { 
        Notice = "TEST", 
        Keywords = 
        [
            "Dog",
            "Cat",
            "Snake",
            "Dolphin",
            "Mammal",
            "O'Clock"
        ] 
    };
    
    [Fact]
    public void ShouldApplyRedactions_WhereStringEndsWithCharacter()
    {
        const string input = "well dog SNAKE mammal what a DogSnake DOG";

        const string expected = "well TEST TEST TEST what a DogSnake TEST";

        var sut = new RedactionService(Config);
        var actual = sut.Redact(input);
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ShouldNotApplyRedaction_WhereCompositeWordExists()
    {
        const string input = "well dog SNAKE what a DogSnake is?";

        const string expected = "well TEST TEST what a DogSnake is?";

        var sut = new RedactionService(Config);
        var actual = sut.Redact(input);
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ShouldApplyRedaction_WhenStringTerminatesWithPunctuation()
    {
        const string input = "'cat', is that your 'thumb'?";
        const string expected = "'TEST', is that your 'thumb'?";

        var sut = new RedactionService(Config);
        var actual = sut.Redact(input);
        Assert.Equal(expected, actual);
    }
}