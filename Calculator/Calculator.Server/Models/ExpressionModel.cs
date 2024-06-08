namespace Calculator.Server.Models
{
    /// <summary>
    /// Модель ввыражения
    /// </summary>
    public class ExpressionModel
    {
        /// <summary>
        /// Первый операнд
        /// </summary>
        public double FirstOperand {  get; set; }
        /// <summary>
        /// Первый операнд
        /// </summary>
        public double SecondOperand {  get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public char Operation {  get; set; }

        /// <summary>
        /// Сравнение двух значений
        /// </summary>
        /// <param name="obj">объект для сравнения с текущим объектом</param>
        /// <returns>Результат сравнения</returns>
        public override bool Equals(object? obj)
        {
            if (obj is ExpressionModel other)
            {
                return FirstOperand == other.FirstOperand
                    && Operation == other.Operation
                    && SecondOperand == other.SecondOperand;
            }
            return false;
        }
    }
}
