using System.Collections.ObjectModel;

namespace Calculator.Server.Providers
{
    /// <summary>
    /// Класс поставщик используемых операций
    /// </summary>
    public class OperationsProvider
    {
        private Collection<char> _operations = new Collection<char>()
        {
            '+',
            '-',
            '*',
            '/'
        };
        public ReadOnlyCollection<char> Operations => new ReadOnlyCollection<char>(_operations);
    }
}
