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

            case '!': AddToken(Match('=') ? TokenType.BANG_EQUAL : TokenType.BANG); break;
            case '=': AddToken(Match('=') ? TokenType.EQUAL_EQUAL : TokenType.EQUAL); break;
            case '<': AddToken(Match('=') ? TokenType.LESS_EQUAL : TokenType.LESS); break;
            case '>': AddToken(Match('=') ? TokenType.GREATER_EQUAL : TokenType.GREATER); break;

            default: ErrorHandler.Error(line, "Unexpected character."); break;
        }
    }

    bool Match(char expected)
    {
        if(IsAtEnd() || source[current] != expected) 
        { 
            return false; 
        }

        current++;
        return true;
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
