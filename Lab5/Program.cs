using System;
using Lab5.Antlr;
using Antlr4.Runtime;

namespace Lab5.Calculator
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string exp = "(2*2) + 15/2";
            var inputStream = new AntlrInputStream(exp);
            var lexer = new CalculatorLexer(inputStream);

            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new CalculatorParser(commonTokenStream);

            var visitor = new CalculatorVisitor();

            var resut = visitor.Visit(parser.expr());

            Console.WriteLine(resut);
        }
    }
}