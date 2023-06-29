namespace Randall.CodeAnalysis
{
    internal sealed class Lexer
    {
        private readonly string _text;
        private int _position;
        private List<string> _diagnotics = new List<string>();

        public Lexer(string text)
        {
            _text = text;
        }

        public IEnumerable<string> Diagnostics => _diagnotics;

        private char Current
        {
            get
            {
                if(_position >= _text.Length)
                    return '\0';
                return _text[_position];
            }
        }

        private void Next()
        {
            _position++;
        }

        public SyntaxToken Lex()
        {
            if (_position >= _text.Length)
            {
                return new SyntaxToken(SyntaxKind.EndOfFileToken, _position, "\0", null);
            }

            if(char.IsDigit(Current))
            {
                var start = _position;

                while(char.IsDigit(Current))
                    Next();
                var length = _position - start;
                var text = _text.Substring(start, length);
                if(!int.TryParse(text, out var value))
                    _diagnotics.Add($"The number {_text} isn't valid INT32.");
                return new SyntaxToken(SyntaxKind.NumberToken, start, text, value);   
            }

            if(char.IsWhiteSpace(Current))
            {
                var start = _position;

                while(char.IsWhiteSpace(Current))
                    Next();

                var length = _position - start;
                var text = _text.Substring(start, length);
                return new SyntaxToken(SyntaxKind.WhiteSpaceToken, start, text, null);
            }

            switch (Current)
            {
                case '+':
                    return new SyntaxToken(SyntaxKind.PlusToken, _position++, "+", null);
                case '-':
                    return new SyntaxToken(SyntaxKind.MinusToken, _position++, "-", null);
                case '*':
                    return new SyntaxToken(SyntaxKind.StarToken, _position++, "*", null);
                case '/':
                    return new SyntaxToken(SyntaxKind.FSlashToken, _position++, "/", null);
                case '(':
                    return new SyntaxToken(SyntaxKind.OpenParenToken, _position++, "(", null);
                case ')':
                    return new SyntaxToken(SyntaxKind.CloseParenToken, _position++, ")", null);
            }

            _diagnotics.Add($"Error: bad character input: '{Current}'");

            return new SyntaxToken(SyntaxKind.BadToken, _position++, _text.Substring(_position -1, 1), null);
        }
    }

}
