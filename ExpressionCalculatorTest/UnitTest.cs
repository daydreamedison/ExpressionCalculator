using ExpressionCalculator;
using System;
using Xunit;

namespace ExpressionCalculatorTest
{
    public class UnitTest
    {
        [Theory]
        [InlineData(" 1 + 1 ", 2)]
        [InlineData(" 1 + 10 - 8 ", 3)]
        [InlineData(" 2 * 7 ", 14)]
        [InlineData(" 10 / 2 ", 5)]
        [InlineData(" 10 / 5 * 4 ", 8)]
        [InlineData(" 10 - ( 7 + 3 ) ", 0)]
        [InlineData(" 10 - 2 * 6 ", -2)]
        public void Test(string input, double expectedOutput)
        {
            var result = Calculator.Calculate(input);

            Assert.Equal(expectedOutput, result);
        }

        [Theory]
        [InlineData(" ( 11.5 + 15.4 ) + 10.1 ", 37)]
        [InlineData(" 23 - ( 29.3 - 12.5 ) ", 6.2)]
        [InlineData(" ( 1 / 2 ) - 1 + 1 ", 0.5)]
        public void TestWithBracket(string input, double expectedOutput)
        {
            var result = Calculator.Calculate(input);

            Assert.Equal(expectedOutput, result);
        }

        [Theory]
        [InlineData(" 1 + 1 ", 2)]
        [InlineData(" 2 * 2 ", 4)]
        [InlineData(" 1 + 2 + 3 ", 6)]
        [InlineData(" 6 / 2 ", 3)]
        [InlineData(" 11 + 23 ", 34)]
        [InlineData(" 11.1 + 23 ", 34.1)]
        [InlineData(" 1 + 1 * 3 ", 4)]
        public void TestWithoutBracket(string input, double expectedOutput)
        {
            var result = Calculator.Calculate(input);

            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void TestExtraBonus()
        {
            var result = Calculator.Calculate(" 10 - ( 2 + 3 * ( 7 - 5 ) ) ");

            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData(" 1 / 0 ")]
        [InlineData(" 1 / ( 7 - 7 ) ")]
        public void TestDivideZero(string input)
        {
            Action act = () => Calculator.Calculate(input);

            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Unable to divide by zero.", exception.Message);
        }

        [Theory]
        [InlineData(" 1 ^ 0 ")]
        [InlineData(" 1 # 23 ")]
        public void TestWrongOperator(string input)
        {
            Action act = () => Calculator.Calculate(input);

            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Invalid math operator", exception.Message);
        }
    }
}
