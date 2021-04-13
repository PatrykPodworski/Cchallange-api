using System.Threading.Tasks;
using CChallange.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CChallangeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubmitTaskController : ControllerBase
    {
        private readonly ILogger<SubmitTaskController> _logger;

        public SubmitTaskController(ILogger<SubmitTaskController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<StatusCodeResult> SubmitAsync(SubmitTaskModel model)
        {
            return new OkResult();
        }
    }
}
