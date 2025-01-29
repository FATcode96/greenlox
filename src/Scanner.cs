namespace greenlox;

public class Scanner(string source)
{
    private readonly List<Token> tokens = [];
    private int start = 0;
    private int current = 0;
    private int line = 1;

    public List<Token> ScanTokens()
    {
        while(!IsAtEnd())
        {
            start = current;
            ScanToken();
        }

        tokens.Add(new Token
        {
            Type = TokenType.EOF,
            Lexeme = string.Empty,
            Literal = null,
            Line = line
        });

        return tokens;
    }

    bool IsAtEnd()
    {
        return current >= source.Length;
    }

    void ScanToken()
    {
        char c = Advance();
        var tokenType = c switch
        {
            '(' => TokenType.LEFT_PAREN,
            ')' => TokenType.RIGHT_PAREN,
            '{' => TokenType.LEFT_BRACE,
            '}' => TokenType.RIGHT_BRACE,
            ',' => TokenType.COMMA,
            '.' => TokenType.DOT,
            '-' => TokenType.MINUS,
            '+' => TokenType.PLUS,
            ';' => TokenType.SEMICOLON,
            '*' => TokenType.STAR,
            _ => TokenType.EOF // Wrong, should return an error
        };

        AddToken(tokenType);
    }

    char Advance()
    {
        return source[current++];
    }

    void AddToken(TokenType tokenType)
    {
        AddToken(tokenType, null);
    }

    void AddToken(TokenType tokenType, object? literal)
    {
        var text = source[start.. current];
        tokens.Add(new Token
        {
            Type = tokenType,
            Lexeme = text,
            Literal = literal,
            Line = line
        });
    }
}
