using System.Reflection;
using System.Text.RegularExpressions;
using Lab3.Core;
using Lab3.Model;

public static class Program
{
    public const string INPUTPATH = @"..\..\..\Input\Input_1.txt";
    public static void Main()
    {
        var inputFile = new Lab3.Model.InputFile(INPUTPATH);
        Tokenizer.Tokenize(inputFile);
        Console.WriteLine(String.Format("| {0,50} | {1,5} |", "Word", "Type"));
        inputFile.Tokens.ForEach(token => Console.WriteLine(String.Format("| {0,50} | {1,5} |", token.Value, token.Type.ToString())));

    }
}