
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsExample
{
    public class FunctionsTime
    {
        private readonly ILogger _logger;

        public FunctionsTime(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FunctionsTime>();
        }

        [Function("Function")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
