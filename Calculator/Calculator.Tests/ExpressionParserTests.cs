using Calculator.Server.Providers;
using Calculator.Server.Parcers;
using Xunit;
using Calculator.Server.Models;

namespace Calculator.Tests
{
    public class ExpressionParserTests
    {
        [Fact]
        public void UncorrectFirstOperandTest()
        {
            // Arrange
            ExpressionParser parser = new ExpressionParser(new OperationsProvider());
            string expressionForParce1 = "@ + 2",
                   expressionForParce2 = "@+2";

            // Act
            Action act1 = () => parser.Parse(expressionForParce1),
                   act2 = () => parser.Parse(expressionForParce2);

            // Assert
            Assert.Throws<ArgumentException>(act1);
            Assert.Throws<ArgumentException>(act2);
        }

        [Fact]
        public void UncorrectSecondOperandTest()
        {
            // Arrange
            ExpressionParser parser = new ExpressionParser(new OperationsProvider());
            string expressionForParce1 = "1 + @",
                   expressionForParce2 = "1+@";

            // Act
            Action act1 = () => parser.Parse(expressionForParce1),
                   act2 = () => parser.Parse(expressionForParce2);

            // Assert
            Assert.Throws<ArgumentException>(act1);
            Assert.Throws<ArgumentException>(act2);
        }

        [Fact]
        public void UncorrectOperationTest()
        {
            // Arrange
            ExpressionParser parser = new ExpressionParser(new OperationsProvider());
            string expressionForParce1 = "1 o 2",
                   expressionForParce2 = "1o2";

            // Act
            Action act1 = () => parser.Parse(expressionForParce1),
                   act2 = () => parser.Parse(expressionForParce2);

            // Assert
            Assert.Throws<ArgumentException>(act1);
            Assert.Throws<ArgumentException>(act2);
        }

        [Fact]
        public void MissingOpearationTest()
        {
            // Arrange
            ExpressionParser parser = new ExpressionParser(new OperationsProvider());
            string expressionForParce1 = "1 2",
                   expressionForParce2 = "12";

            // Act
            Action act1 = () => parser.Parse(expressionForParce1),
                   act2 = () => parser.Parse(expressionForParce2);

            // Assert
            Assert.Throws<ArgumentException>(act1);
            Assert.Throws<ArgumentException>(act2);
        }

        [Fact]
        public void CorrectExpressionTest()
        {
            // Arrange
            ExpressionModel correctExpression = new ExpressionModel()
            {
                FirstOperand = 1,
                SecondOperand = 2,
                Operation = '+'
            };

            ExpressionParser parser = new ExpressionParser(new OperationsProvider());

            string expressionForParce1 = "  1  +  2  ",
                   expressionForParce2 = "  1  +2  ",
                   expressionForParce3 = "  1+  2  ",
                   expressionForParce4 = "1  + 2",
                   expressionForParce5 = "1 +  2",
                   expressionForParce6 = "1+2";

            // Act
            ExpressionModel expression1 = parser.Parse(expressionForParce1),
                            expression2 = parser.Parse(expressionForParce2),
                            expression3 = parser.Parse(expressionForParce3),
                            expression4 = parser.Parse(expressionForParce4),
                            expression5 = parser.Parse(expressionForParce5),
                            expression6 = parser.Parse(expressionForParce6);

            // Assert
            Assert.NotNull(expression1);
            Assert.NotNull(expression2);
            Assert.NotNull(expression3);
            Assert.NotNull(expression4);
            Assert.NotNull(expression5);
            Assert.NotNull(expression6);

            Assert.Equal(expression1, correctExpression);
            Assert.Equal(expression2, correctExpression);
            Assert.Equal(expression3, correctExpression);
            Assert.Equal(expression4, correctExpression);
            Assert.Equal(expression5, correctExpression);
            Assert.Equal(expression6, correctExpression);
        }
    }
}
