using System.Threading.Tasks;
using CChallange.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CChallangeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HighscoresController : ControllerBase
    {
        private readonly ILogger<SubmitTaskController> _logger;
        private readonly IHighscoresService highscoresService;

        public HighscoresController(IHighscoresService highscoresService)
        {
            this.highscoresService = highscoresService;
        }

        [HttpGet]
        public async Task<ActionResult> GetHighscores()
        {
            var highscores = await highscoresService.GetHighscores().ConfigureAwait(false);

            return new OkObjectResult(highscores);
        }
    }
}
