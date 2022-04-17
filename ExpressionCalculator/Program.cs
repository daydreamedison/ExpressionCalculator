using System;

namespace ExpressionCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Expression Calculator");

            Console.WriteLine(" 1 + 1 = {0}", Calculator.Calculate(" 1 + 1 "));
            Console.WriteLine(" 2 * 2 = {0}", Calculator.Calculate(" 2 * 2 "));
            Console.WriteLine(" 1 + 2 + 3 = {0}", Calculator.Calculate(" 1 + 2 + 3 "));
            Console.WriteLine(" 6 / 2 = {0}", Calculator.Calculate(" 6 / 2 "));
            Console.WriteLine(" 11 + 23 = {0}", Calculator.Calculate(" 11 + 23 "));
            Console.WriteLine(" 11.1 + 23 = {0}", Calculator.Calculate(" 11.1 + 23 "));
            Console.WriteLine(" 1 + 1 * 3 = {0}", Calculator.Calculate(" 1 + 1 * 3 "));
            Console.WriteLine(" ( 11.5 + 15.4 ) + 10.1 = {0}", Calculator.Calculate(" ( 11.5 + 15.4 ) + 10.1 "));
            Console.WriteLine(" 23 - ( 29.3 - 12.5 ) = {0}", Calculator.Calculate(" 23 - ( 29.3 - 12.5 ) "));
            Console.WriteLine(" ( 1 / 2 ) - 1 + 1 = {0}", Calculator.Calculate(" ( 1 / 2 ) - 1 + 1 "));
            Console.WriteLine(" 10 - ( 2 + 3 * ( 7 - 5 ) ) = {0}", Calculator.Calculate(" 10 - ( 2 + 3 * ( 7 - 5 ) ) "));

            Console.ReadLine();
        }


    }
}
