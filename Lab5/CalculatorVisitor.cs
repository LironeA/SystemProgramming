using System;
using Lab5.Antlr;

namespace Lab5.Calculator
{
    public class CalculatorVisitor : CalculatorParserBaseVisitor<double>
    {
        public override double VisitMulDiv(CalculatorParser.MulDivContext context)
        {
            var left = Visit(context.left);
            var right = Visit(context.right);

            if (context.op.Type == CalculatorLexer.STAR)
            {
                return left * right;
            }

            return left / right;
        }

        public override double VisitAddSub(CalculatorParser.AddSubContext context)
        {
            var left = Visit(context.left);
            var right = Visit(context.right);

            if (context.op.Type == CalculatorLexer.PLUS)
            {
                return left + right;
            }

            return left - right;
        }

        public override double VisitParen(CalculatorParser.ParenContext context)
        {
            return Visit(context.expr());
        }

        public override double VisitConstant(CalculatorParser.ConstantContext context)
        {
            if (context.INT() != null)
            {
                return Convert.ToInt32(context.INT().GetText());
            }

            if (context.DOUBLE() != null)
            {
                return Convert.ToDouble(context.DOUBLE().GetText());
            }

            return 0;
        }
    }
}