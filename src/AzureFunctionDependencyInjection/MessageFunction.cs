using AzureFunctionDependencyInjection.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureFunctionDependencyInjection
{
    public class MessageFunction
    {
        private IMessageResponderService _messageResponderService;
        private ILogger _logger;

        public MessageFunction(IMessageResponderService messageResponderService, ILoggerFactory loggerFactory)
        {
            _messageResponderService = messageResponderService;
            _logger = loggerFactory.CreateLogger<MessageFunction>();
        }

        [FunctionName("positive")]
        public async Task<IActionResult> GetPositiveMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(_messageResponderService.GetPositiveMessage());
        }

        [FunctionName("negative")]
        public async Task<IActionResult> GetNegativeMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(_messageResponderService.GetNegativeMessage());
        }
    }
}