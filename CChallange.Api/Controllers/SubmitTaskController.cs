using System.Threading.Tasks;
using CChallange.Api.Models;
using CChallange.SubmitionsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CChallangeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubmitTaskController : ControllerBase
    {
        private readonly ILogger<SubmitTaskController> _logger;
        private readonly ISubmitionService submitionService;

        public SubmitTaskController(ILogger<SubmitTaskController> logger, ISubmitionService submitionService)
        {
            _logger = logger;
            this.submitionService = submitionService;
        }

        [HttpPost]
        public async Task<ActionResult> SubmitAsync(SubmitTaskModel model)
        {
            var isSolutionCorrect = await submitionService.SubmitAsync(model.TaskId.ToString(), model.SubmissionerName, model.SolutionCode);

            if (isSolutionCorrect)
            {
                return new OkObjectResult("Solution is correct");
            }

            return new OkObjectResult("Solution is incorrect");
        }
    }
}
