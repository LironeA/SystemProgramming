using System.Text;
using Lab1.Model;

namespace Lab1.Core;

public static class Tokenizer
{
    static Tokenizer() {}

    public static void Tokenize(InputFile inputFile, List<char> separators = null)
    {
        var filesteram = inputFile.FileStream;
        byte[] buffer = new byte[filesteram.Length];
        filesteram.Read(buffer, 0, buffer.Length);
        string input = Encoding.UTF8.GetString(buffer).Trim();
        input = input.Substring(1, input.Length - 2);
        separators = separators ?? new List<char> { ' ', '.', ',', '?', '!', '\n', '\t' };
        
        
        List<string> tokens = input.Split(separators.ToArray()).ToList();
        tokens.RemoveAll(token => token == "");
        
        foreach (var tokenString in tokens)
        {
            Token t = inputFile.Tokens.Find(x => x.Value == tokenString);
            if(t != null)
            {
                t.Count++;
                continue;
            }
            var token = new Token();
            token.Value = tokenString;
            token.Count = 1;
            inputFile.Tokens.Add(token);
        }
    }
}