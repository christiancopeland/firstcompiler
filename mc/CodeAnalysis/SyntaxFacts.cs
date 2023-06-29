namespace Randall.CodeAnalysis
{
    internal static class SyntaxFacts
    {
        public static int GetBinaryOperatorPrecendence(this SyntaxKind kind)
        {
            switch(kind)
            {
                case SyntaxKind.StarToken:
                case SyntaxKind.FSlashToken:
                    return 2;
                case SyntaxKind.PlusToken:
                case SyntaxKind.MinusToken:
                    return 1;
                default:
                    return 0;
            }
        }

    }

}
