using Xunit;
using Calculator.Server.Services;
using Calculator.Server.Models;

namespace Calculator.Tests
{
    public class ComputingServerTest
    {
        [Fact]
        public void CorrectDivideTest()
        {
            //Arrange
            ComputingService computingService = new ComputingService();

            ExpressionModel expressionMessage = new ExpressionModel()
            {
                FirstOperand = 1,
                SecondOperand = 3,
                Operation = '/'
            };

            //Act
            double result = computingService.Compute(expressionMessage);
            // Assert
            Assert.Equal(1.0 / 3.0, result, 10);

        }

        [Fact]
        public void DividebyZeroTest()
        {
            //Arrange
            ComputingService computingService = new ComputingService();

            ExpressionModel expressionMessage = new ExpressionModel()
            {
                FirstOperand = 1,
                SecondOperand = 0,
                Operation = '/'
            };

            //Act
            Action act = () => computingService.Compute(expressionMessage);
            // Assert
            Assert.Throws<DivideByZeroException>(act);
        }

        [Fact]
        public void MultiplicationTest()
        {
            //Arrange
            ComputingService computingService = new ComputingService();

            ExpressionModel expressionMessage = new ExpressionModel()
            {
                FirstOperand = 5,
                SecondOperand = 10,
                Operation = '*'
            };

            //Act
            double result = computingService.Compute(expressionMessage);
            // Assert
            Assert.Equal(50.0, result, 10);
        }
        [Fact]
        public void SubtractionTest()
        {
            //Arrange
            ComputingService computingService = new ComputingService();

            ExpressionModel expressionMessage = new ExpressionModel()
            {
                FirstOperand = 27,
                SecondOperand = 33,
                Operation = '-'
            };

            //Act
            double result = computingService.Compute(expressionMessage);
            // Assert
            Assert.Equal(-6.0, result, 10);
        }
        [Fact]
        public void AdditionTest()
        {
            //Arrange
            ComputingService computingService = new ComputingService();

            ExpressionModel expressionMessage = new ExpressionModel()
            {
                FirstOperand = 2,
                SecondOperand = 3,
                Operation = '+'
            };

            //Act
            double result = computingService.Compute(expressionMessage);
            // Assert
            Assert.Equal(5.0, result, 10);
        }

        [Fact]
        public void UncorrectExpressionTest()
        {
            //Arrange
            ComputingService computingService = new ComputingService();

            ExpressionModel expressionMessage = new ExpressionModel()
            {
                FirstOperand = 2,
                SecondOperand = 3,
                Operation = ')'
            };

            //Act
            Action act = () => computingService.Compute(expressionMessage);
            // Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}
