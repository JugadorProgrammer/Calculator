using Calculator.Server.Parcers;
using Calculator.Server.Providers;
using Calculator.Server.Services;
using Calculator.Server.Services.gRPC;

namespace Calculator.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddGrpc();

            builder.Services.AddTransient<ComputingService>();
            builder.Services.AddTransient<ExpressionParser>();
            builder.Services.AddTransient<OperationsProvider>();

            var app = builder.Build();

            app.MapGrpcService<CalculatorService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}