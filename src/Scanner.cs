namespace greenlox;

public class Scanner(string source)
{
    private readonly List<Token> tokens = [];
    private int start = 0;
    private int current = 0;
    private int line = 1;
    private bool hadError = false;

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
        
        switch(c) 
        {
            case '(': AddToken(TokenType.LEFT_PAREN); break;
            case ')': AddToken(TokenType.RIGHT_PAREN); break;
            case '{': AddToken(TokenType.LEFT_BRACE); break;
            case '}': AddToken(TokenType.RIGHT_BRACE); break;
            case ',': AddToken(TokenType.COMMA); break;
            case '.': AddToken(TokenType.DOT); break;
            case '-': AddToken(TokenType.MINUS); break;
            case '+': AddToken(TokenType.PLUS); break;
            case ';': AddToken(TokenType.SEMICOLON); break;
            case '*': AddToken(TokenType.STAR); break;
            default: Error(line, "Unexpected character."); break;
        }
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

    void Error(int line, string message)
    {
        Report(line, string.Empty, message);
    }

    void Report(int line, string where, string message)
    {
        Console.WriteLine($"[line {line}] Error {where}: {message}");
        hadError = true;
    }
}
