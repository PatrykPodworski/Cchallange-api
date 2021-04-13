using System.Threading.Tasks;
using CChallange.Api.Models;
using CChallange.Services;
using Microsoft.AspNetCore.Mvc;

namespace CChallangeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubmitTaskController : ControllerBase
    {
        private readonly ISubmitionService submitionService;

        public SubmitTaskController(ISubmitionService submitionService)
        {
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
