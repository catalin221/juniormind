using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApplications
{
    public static class ReversePolishNotation
    {
        public static double CalculateExpression(string expression)
        {
            ThrowNullException(expression);

            return expression.Split().Aggregate(Enumerable.Empty<double>(), (operands, current) => IsOperator(current)
                                    ? UpdateResult(operands, current, 2)
                                    : operands.Append(Convert.ToDouble(current))).First();
        }

        private static IEnumerable<double> UpdateResult(IEnumerable<double> operands, string current, int skip)
        {
            return operands.SkipLast(skip).Append(ApplyOperator(operands.TakeLast(skip), current));
        }

        private static double ApplyOperator(IEnumerable<double> operands, string operation)
        {
            double firstOperand = operands.First();
            double secondOperand = operands.Last();
            return operation switch
            {
                "+" => firstOperand + secondOperand,
                "-" => firstOperand - secondOperand,
                "*" => firstOperand * secondOperand,
                "/" => firstOperand / secondOperand,
            };
        }

        private static bool IsOperator(string element)
        {
            return "+-*/".Contains(element);
        }

        private static void ThrowNullException(string source)
        {
            if (source != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(source));
        }
    }
}
