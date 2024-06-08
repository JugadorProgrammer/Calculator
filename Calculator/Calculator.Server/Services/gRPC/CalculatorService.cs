using Calculator.Server.Models;
using Calculator.Server.Parcers;
using Grpc.Core;

namespace Calculator.Server.Services.gRPC
{
    public class CalculatorService : Calculator.CalculatorBase
    {
        private readonly ExpressionParser _expressionParcer;
        private readonly ComputingService _computingService;
        public CalculatorService(ExpressionParser expressionParcer, ComputingService computingService)
        {
            _expressionParcer = expressionParcer;
            _computingService = computingService;
        }

        public override Task<ResultMessage> SendExpression(ExpressionMessage request, ServerCallContext context)
        {
            var resultMeassage = new ResultMessage();

            try
            {
                var model = _expressionParcer.Parse(request.Expression);
                resultMeassage.Result = _computingService.Compute(model).ToString();
            }
            catch (Exception exception)
            {
                resultMeassage.Result = $"Error: {exception.Message}";
            }

            return Task.FromResult(resultMeassage);
        }
    }
}
