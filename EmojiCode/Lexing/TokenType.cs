namespace EmojiCode.Lexing
{
    public enum TokenType
    {
        Plus,       // ➕ (U+2795)
        Minus,      // ➖ (U+2796)
        Multiply,   // ✖️ (U+2716)
        Divide,     // ➗ (U+2797)
        Equal,      // 🟰 (U+1F7F0)
        NotEqual,   // ❗🟰 (U+2757 U+1F7F0)
        Greater,    // 🔼 (U+1F53C)
        Less,       // 🔽 (U+1F53D)
        If,         // ❓ (U+2753)
        Else,       // ➡️ (U+27A1)
        EndIf,      // 🛑 (U+1F6D1)
        While,      // 🔄 (U+1F504)
        EndWhile,   // 🔚 (U+1F51A)
        Variable,   // 🔤 (U+1F524)
        Assign,     // 📝 (U+1F4DD)
        Print,      // 📤 (U+1F4E4)
        Read,       // 📥 (U+1F4E5)
        And,        // 🟢 (U+1F7E2)
        Or,         // 🟠 (U+1F7E0)
        Not,        // 🚫 (U+1F6AB)
        DefineFunc, // 🔧 (U+1F527)
        EndFunc,    // 🔨 (U+1F528)
        CallFunc,   // 🔙 (U+1F519)
        Number,     // eine Zahl
        EOF         // End of File
    }
}