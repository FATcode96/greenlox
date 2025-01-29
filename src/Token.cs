namespace greenlox;

public record class Token
{
    public TokenType Type { get; set; } = TokenType.EOF;
    public string Lexeme { get; set; } = string.Empty;
    public object? Literal { get; set; }
    public int Line { get; set; } = 0;
}
