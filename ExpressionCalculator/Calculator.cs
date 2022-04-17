using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionCalculator
{
    public class Calculator
    {
        private static string[] _inputArray;

        private readonly static int _decimalPlace = 2;

        public static double Calculate(string input)
        {
            _inputArray = input.Split(' ');

            Stack<char> operators = new Stack<char>();
            Stack<double> values = new Stack<double>();

            for(int i = 0; i < _inputArray.Length; i++)
            {
                if (_inputArray[i] == string.Empty)
                    continue;

                if(double.TryParse(_inputArray[i], out double number))
                {
                    values.Push(number);
                }
                else if (_inputArray[i] == "(")
                {
                    operators.Push('(');
                }
                else if (_inputArray[i] == ")")
                {
                    while (operators.Count > 0 && operators.Peek() != '(')
                    {
                        values.Push(Compute(operators.Pop(), values.Pop(), values.Pop()));
                    }

                    operators.Pop();
                }
                else if (IsOperator(_inputArray[i], out char op))
                {
                    while(operators.Count > 0 
                        && ( IsLowerPriority(operators.Peek(), op)
                            || IsSamePriority(operators.Peek(), op)))
                    {
                        values.Push(Compute(operators.Pop(), values.Pop(), values.Pop()));
                    }

                    operators.Push(op);
                }
            }


            while(operators.Count > 0)
            {
                values.Push(Compute(operators.Pop(), values.Pop(), values.Pop()));
            }

            return Math.Round(values.Pop(), _decimalPlace);
            
        }

        static bool IsOperator(string input, out char op)
        {
            switch (input) 
            {
                case "+":
                    op = '+';
                    return true;
                case "-":
                    op = '-';
                    return true;
                case "*":
                    op = '*';
                    return true;
                case "/":
                    op = '/';
                    return true;
                default:
                    throw new ArgumentException("Invalid Operator");
            }

        }

        static bool IsLowerPriority(char prev, char now)
        {
            if(now == '+' || now == '-')
            {
                if(prev == '*' || prev == '/')
                {
                    return true;
                }
            }

            return false;
        }

        static bool IsSamePriority(char prev, char now)
        {
            if(prev == '*' || prev == '/')
            {
                if ( now == '*' || now == '/')
                {
                    return true;
                }
            }
            else if (prev == '+' || prev == '-')
            {
                if ( now == '+' || now == '-')
                {
                    return true;
                }
            }

            return false;
        }

        static double Compute(char op, double num2, double num1)
        {
            switch (op)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    return num1 / num2;
                default:
                    throw new ArgumentException("Invalid math operator");
            }
        }
    }
}
