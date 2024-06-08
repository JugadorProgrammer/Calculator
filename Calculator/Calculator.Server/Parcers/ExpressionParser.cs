using Calculator.Server.Models;
using Calculator.Server.Providers;

namespace Calculator.Server.Parcers
{
    /// <summary>
    /// Класс для перевода строки в ExpressionModel
    /// </summary>
    public class ExpressionParser
    {
        private readonly OperationsProvider _operationsModel;
        public ExpressionParser(OperationsProvider operationsModel)
        {
            _operationsModel = operationsModel;
        }

        /// <summary>
        /// Разбор выражения
        /// </summary>
        /// <param name="expression">полученное выражение</param>
        /// <returns>Выражение</returns>
        public ExpressionModel Parse(string expression)
        {
            string[] data;
            double firstParametr, secondParametr;

            foreach (var action in _operationsModel.Operations)
            {
                data = expression.Trim().Split(action);
                if (data.Length == 2)
                {
                    if (!double.TryParse(data[0], out firstParametr))
                    {
                        throw new ArgumentException("Invalid firstParametr in expression");
                    }
                    
                    if (!double.TryParse(data[1], out secondParametr))
                    {
                        throw new ArgumentException("Invalid secondParametr in expression");
                    }

                    var model = new ExpressionModel()
                    {
                        Operation = action,
                        FirstOperand = firstParametr,
                        SecondOperand = secondParametr
                    };

                    return model;
                }
            }

            throw new ArgumentException("Invalid expression for parsing");
        }
    }
}
