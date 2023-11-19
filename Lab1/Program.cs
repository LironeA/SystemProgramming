using System.Reflection;
using Lab1.Core;
using Lab1.Model;

public static class Program
{
    public const string INPUTPATH = @"..\..\..\Input\Input_1.txt";
    public static void Main()
    {
        var inputFile = new Lab1.Model.InputFile(INPUTPATH);
        Tokenizer.Tokenize(inputFile);
        Console.WriteLine("Tokens:");
        Console.WriteLine(String.Format("| {0,30} | {1,5} |", "Word", "Count"));
        Console.WriteLine("------------------------------------------");
        inputFile.Tokens.ForEach(token => Console.WriteLine(String.Format("| {0,30} | {1,5} |", token.Value, token.Count)));
        Console.WriteLine("------------------------------------------");
        Console.WriteLine(String.Format("| {0,30} | {1,5} |", "Total", inputFile.Tokens.Sum(token => token.Count)));
    }
}