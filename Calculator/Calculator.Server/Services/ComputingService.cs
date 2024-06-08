using Calculator.Server.Models;

namespace Calculator.Server.Services
{
    public class ComputingService
    {
        /// <summary>
        /// Вычисление выражения
        /// </summary>
        /// <param name="expression">выражение</param>
        /// <returns>Результат вычисления</returns>
        /// <exception cref="DivideByZeroException">Деление на ноль</exception>
        /// <exception cref="ArgumentException">Некорректная операция</exception>
        public double Compute(ExpressionModel expression)
        {
            return expression.Operation switch
            {
                '+' => expression.FirstOperand + expression.SecondOperand,
                '-' => expression.FirstOperand - expression.SecondOperand,
                '*' => expression.FirstOperand * expression.SecondOperand,
                '/' => expression.SecondOperand == 0 ?
                    throw new DivideByZeroException() : expression.FirstOperand / expression.SecondOperand,

                _ => throw new ArgumentException("This operation cannot be performed!")
            };
        }
    }
}
