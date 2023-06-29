namespace Randall.CodeAnalysis
{
    public enum SyntaxKind 
    {
        // tokens
        BadToken,
        EndOfFileToken,
        WhiteSpaceToken,
        NumberToken,
        PlusToken,
        MinusToken,
        StarToken,
        FSlashToken,
        OpenParenToken,
        CloseParenToken,

        // expressions
        NumberExpression,
        BinaryExpression,
        ParenthesizedExpression,
        LiteralExpression
    }

}
