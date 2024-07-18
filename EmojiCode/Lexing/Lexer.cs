namespace EmojiCode.Lexing
{
    public class Lexer
    {
        private readonly string _input;
        private int _position;
        private Dictionary<string, TokenType> _emojiTokenMap = [];

        public Lexer(string input)
        {
            _input = input;
            InitializeEmojiTokenMap();
        }

        public Token GetNextToken()
        {
            SkipWhitespace();

            if (_position >= _input.Length)
            {
                return new Token(TokenType.EOF, string.Empty);
            }

            foreach (var emoji in _emojiTokenMap.Keys)
            {
                if (!_input[_position..].StartsWith(emoji)) 
                    continue;
                
                _position += emoji.Length;
                return new Token(_emojiTokenMap[emoji], emoji);
            }
            
            if (char.IsDigit(_input[_position]))
            {
                return new Token(TokenType.Number, GetNumber());
            }

            throw new Exception($"Unknown Symbol: {_input[_position]}");
        }
        
        public List<Token> GetAllTokens()
        {
            var tokens = new List<Token>();
            
            Token token;
            do
            {
                token = GetNextToken();
                tokens.Add(token);
            } while (token.Type != TokenType.EOF);

            return tokens;
        }

        private void SkipWhitespace()
        {
            while (_position < _input.Length && char.IsWhiteSpace(_input[_position]))
            {
                _position++;
            }
        }

        private string GetNumber()
        {
            var start = _position;
            while (_position < _input.Length && char.IsDigit(_input[_position]))
            {
                _position++;
            }
            return _input.Substring(start, _position - start);
        }

        private void InitializeEmojiTokenMap()
        {
            _emojiTokenMap = new Dictionary<string, TokenType>
            {
                { "➕", TokenType.Plus },
                { "➖", TokenType.Minus },
                { "✖️", TokenType.Multiply },
                { "➗", TokenType.Divide },
                { "🟰", TokenType.Equal },
                { "❗🟰", TokenType.NotEqual },
                { "🔼", TokenType.Greater },
                { "🔽", TokenType.Less },
                { "❓", TokenType.If },
                { "➡️", TokenType.Else },
                { "🛑", TokenType.EndIf },
                { "🔄", TokenType.While },
                { "🔚", TokenType.EndWhile },
                { "🔤", TokenType.Variable },
                { "📝", TokenType.Assign },
                { "📤", TokenType.Print },
                { "📥", TokenType.Read },
                { "🟢", TokenType.And },
                { "🟠", TokenType.Or },
                { "🚫", TokenType.Not },
                { "🔧", TokenType.DefineFunc },
                { "🔨", TokenType.EndFunc },
                { "🔙", TokenType.CallFunc }
            };
        }
    }
}