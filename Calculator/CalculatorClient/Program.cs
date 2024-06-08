using Grpc.Net.Client;
using Newtonsoft.Json;

namespace CalculatorClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            RequestData? data;
            //Чтение даннх из файла конфигураций
            using (var stream = new StreamReader("..//..//..//Config//appconfig.json"))
            {
                data = JsonConvert.DeserializeObject<RequestData>(await stream.ReadToEndAsync());
                if (data is null)
                {
                    Console.WriteLine("Configuration file with settings was not found!");
                    Console.ReadKey();
                    return;
                }
            }
            
            bool restart = false;
            Console.WriteLine("Welcome to calculator !");
            do
            {
                Console.Write("\nPlease write expression like '{first operand} {opertion} {second operand}': ");
                var expression = Console.ReadLine();

                //создание подключения
                using (var channel = GrpcChannel.ForAddress(data.RequestUrl))
                {
                    var client = new Calculator.Client.Calculator.CalculatorClient(channel);

                    var result = client.SendExpression(new Calculator.Client.ExpressionMessage { Expression = expression });

                    if (result is null)
                    {
                        Console.WriteLine("The server isn't responding!");
                    }
                    else
                    {
                        Console.WriteLine($"Result - {result.Result}");
                    }
                    Console.Write("Do you wont to repeat?(y/n) ");
                    var answer = Console.ReadLine();

                    restart = answer is not null && answer.ToLower().Contains('y');
                }

            } while (restart);

            Console.Write("Good buy!");
            Console.ReadKey();
        }
    }
}
