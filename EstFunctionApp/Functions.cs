using EstLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace EstFunctionApp
{
    public class Functions
    {
        private readonly ITaxService _taxService;
        public Functions(ITaxService taxService)
        {
            _taxService = taxService;
        }

        [FunctionName("GetEst")]
        public IActionResult GetEst(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetEst function processed a request.");

            int year = int.Parse(req.Query["year"]);
            bool isSingle = bool.Parse(req.Query["isSingle"]);
            decimal taxableIncome = decimal.Parse(req.Query["taxableIncome"]);

            var result = _taxService.GetTax(year, isSingle, taxableIncome);
            return new OkObjectResult(result);
        }
    }
}
