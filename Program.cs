using EmojiCode.Lexing;

namespace EmojiCode;

internal static class Program
{
    private const bool Debug = true;
    
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        const string input = "📤 3 ➕ 4";

        var lexer = new Lexer(input);
        var tokens = lexer.GetAllTokens();
        
        if(Debug)
            OutputTokens(tokens);
        
        
    }
    
    private static void OutputTokens(List<Token> tokens)
    {
        foreach (var token in tokens)
        {
            Console.WriteLine($"Type: {token.Type}, Value: {token.Value}");
        }
    }
}