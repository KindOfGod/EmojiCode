using System.Diagnostics.CodeAnalysis;
using EmojiCode.Lexing;
using EmojiCode.Parsing.Nodes;
using EmojiCode.Parsing.Nodes.Base;

namespace EmojiCode.Parsing;

[SuppressMessage("Performance", "CA1859:Use concrete types when possible for improved performance")]
public class Parser
{
    private readonly Lexer _lexer;
    private Token _currentToken;

    public Parser(Lexer lexer)
    {
        _lexer = lexer;
        _currentToken = _lexer.GetNextToken();
    }

    private void Eat(TokenType tokenType)
    {
        if (_currentToken.Type == tokenType)
        {
            _currentToken = _lexer.GetNextToken();
        }
        else
        {
            throw new Exception($"Expected {tokenType}, Found {_currentToken.Type}");
        }
    }

    public BranchNode Parse()
    {
        return ParseStatement();
    }

    private BranchNode ParseStatement()
    {
        return _currentToken.Type switch
        {
            TokenType.Print => ParsePrintStatement(),
            TokenType.Read => ParseReadStatement(),
            TokenType.If => ParseIfStatement(),
            TokenType.While => ParseWhileLoop(),
            _ => ParseExpression()
        };
    }

    private BranchNode ParsePrintStatement()
    {
        Eat(TokenType.Print);
        var expression = ParseExpression();
        
        return new PrintNode(expression);
    }

    private BranchNode ParseReadStatement()
    {
        Eat(TokenType.Read);
        // Assuming that the next token is a variable
        if (_currentToken.Type != TokenType.Variable)
        {
            throw new Exception("Expected a variable name after the Read statement");
        }
        
        var variableName = _currentToken.Value;
        Eat(TokenType.Variable);
        
        return new ReadNode(new VariableNode(variableName));
    }

    private BranchNode ParseIfStatement()
    {
        Eat(TokenType.If);
        var condition = ParseExpression();
        var trueBranch = ParseStatement();
        
        Eat(TokenType.Else);
        var falseBranch = ParseStatement();
        
        Eat(TokenType.EndIf);
        
        return new IfStatementNode(condition, trueBranch, falseBranch);
    }

    private BranchNode ParseWhileLoop()
    {
        Eat(TokenType.While);
        var condition = ParseExpression();
        var body = ParseStatement();
        
        Eat(TokenType.EndWhile);
        
        return new WhileLoopNode(condition, body);
    }

    private BranchNode ParseExpression()
    {
        var left = ParseTerm();

        while (_currentToken.Type is TokenType.Plus or TokenType.Minus)
        {
            var op = _currentToken.Type;
            Eat(op);
            
            var right = ParseTerm();
            left = new BinaryOperationNode(left, op, right);
        }

        return left;
    }

    private BranchNode ParseTerm()
    {
        var left = ParseFactor();

        while (_currentToken.Type is TokenType.Multiply or TokenType.Divide)
        {
            var op = _currentToken.Type;
            Eat(op);
            
            var right = ParseFactor();
            left = new BinaryOperationNode(left, op, right);
        }

        return left;
    }

    private BranchNode ParseFactor()
    {
        if (_currentToken.Type != TokenType.Number) 
            throw new Exception("Unknown Expression");
        
        var value = _currentToken.Value;
        Eat(TokenType.Number);
        
        return new NumberNode(value);

    }
}