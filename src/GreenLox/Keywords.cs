﻿namespace greenlox;

public static class Keywords
{
    public static readonly Dictionary<string, TokenType> GetValues = new()
    {
        {"and", TokenType.AND },
        {"class", TokenType.CLASS },
        {"else", TokenType.ELSE },
        {"false", TokenType.FALSE },
        {"for", TokenType.FOR },
        {"fun", TokenType.FUN },
        {"if", TokenType.IF },
        {"nil", TokenType.NIL },
        {"or", TokenType.OR },
        {"print", TokenType.PRINT },
        {"return", TokenType.RETURN },
        {"super", TokenType.SUPER },
        {"this", TokenType.THIS },
        {"true", TokenType.TRUE },
        {"var", TokenType.VAR },
        {"while", TokenType.WHILE }
    };
}
