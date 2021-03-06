﻿namespace LhsBracketParser
{

    public enum TokenType
    {
        Identifier = 1,
        Number,
        Date,
        String,
        Boolean,
        Range,
        Like,
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        ParenthesesOpen,
        ParenthesesClose,
        EndOfLine,
        And,
        Or
    }
}
