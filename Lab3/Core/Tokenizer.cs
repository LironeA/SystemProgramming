using System.Text;
using System.Text.RegularExpressions;
using Lab3.Model;

namespace Lab3.Core;

public static class Tokenizer
{
    private static string delimetersRegex =
        @"[^(#|@)\w\s]";

    private static string commentsRegex =
        @"(/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/)|(//.*)";
    
    private static string preprocessorsRegex =
        @"^\s*#\s*(define|undef|if|else|elif|endif|region|endregion|error|warning|line|pragma)\b.*";

    private static string operatorRegex =
        @"(?<!/)/(?!/)|\+|\-|\*|\%|\=|\==|\!=|\<|\>|\<=|\>=|\&\&|\|\||\!|\~|\&|\||\^|\<<|\>>|\+\+|\-\-";
    
    private static string reservedWordsRegex =
        @"\b(?<!#)(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while)\b";

    private static string identifierRegex =
        @"[a-zA-Z_][a-zA-Z0-9_]*";
    
    private  static string numberRegex =
        @"[0-9]+(\.[0-9]+)?";
    
    static Tokenizer() {}

    public static void Tokenize(InputFile inputFile, List<char> separators = null)
    {
        var filesteram = inputFile.FileStream;
        byte[] buffer = new byte[filesteram.Length];
        filesteram.Read(buffer, 0, buffer.Length);
        string input = Encoding.UTF8.GetString(buffer).Replace("\t", "").Replace("\r", "").Trim();
        input = input.Substring(1, input.Length - 2);
        
        
        
        var comments = Regex.Matches(input, commentsRegex, RegexOptions.Multiline);
        
        foreach (Match match in comments)
        {
            var token = new Token();
            token.Value = match.Value;
            token.Type = TokenType.Comment;
            inputFile.Tokens.Add(token);
        }
        
        var preprocessors = Regex.Matches(input, preprocessorsRegex, RegexOptions.Multiline);
        
        foreach (Match match in preprocessors)
        {
            var token = new Token();
            token.Value = match.Value;
            token.Type = TokenType.PreprocessorDirective;
            inputFile.Tokens.Add(token);
        }
        
        var operators = Regex.Matches(input, operatorRegex, RegexOptions.Multiline);
        
        foreach (Match match in operators)
        {
            var token = new Token();
            token.Value = match.Value;
            token.Type = TokenType.Operator;
            inputFile.Tokens.Add(token);
        }
        
        var delimeters = Regex.Matches(input, delimetersRegex, RegexOptions.Multiline);
        
        foreach (Match match in delimeters)
        {
            var token = new Token();
            token.Value = match.Value;
            token.Type = TokenType.Delimiter;
            if(inputFile.Tokens.Find(x => x.Value == token.Value) == null)
                inputFile.Tokens.Add(token);
        }
        
        var reservedWords = Regex.Matches(input, reservedWordsRegex, RegexOptions.Multiline);
        
        foreach (Match match in reservedWords)
        {
            
            var token = new Token();
            token.Value = match.Value;
            token.Type = TokenType.ReservedWord;
            inputFile.Tokens.Add(token);
        }
        
        var identifiers = Regex.Matches(input, identifierRegex, RegexOptions.Multiline);
        
        foreach (Match match in identifiers)
        {
            var token = new Token();
            token.Value = match.Value;
            token.Type = TokenType.Identifier;
            if(inputFile.Tokens.Find(x => x.Value == token.Value) == null)
                inputFile.Tokens.Add(token);
        }
        
        var numbers = Regex.Matches(input, numberRegex, RegexOptions.Multiline);
        
        foreach (Match match in numbers)
        {
            var token = new Token();
            token.Value = match.Value;
            token.Type = TokenType.Number;
            inputFile.Tokens.Add(token);
        }
        
        
        
        

        // foreach (var tokenString in tokens)
        // {
        //     Token t = inputFile.Tokens.Find(x => x.Value == tokenString);
        //     if(t != null)
        //     {
        //         t.Count++;
        //         continue;
        //     }
        //     var token = new Token();
        //     token.Value = tokenString;
        //     token.Count = 1;
        //     inputFile.Tokens.Add(token);
        // }
    }
}