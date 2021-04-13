﻿using System.Threading.Tasks;
using CChallange.Api.Models;
using CChallange.JdoodleService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CChallangeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubmitTaskController : ControllerBase
    {
        private readonly ILogger<SubmitTaskController> _logger;
        private readonly IJdoodleService jdoodleService;

        public SubmitTaskController(ILogger<SubmitTaskController> logger, IJdoodleService  jdoodleService)
        {
            _logger = logger;
            this.jdoodleService = jdoodleService;
        }

        [HttpPost]
        public async Task<StatusCodeResult> SubmitAsync(SubmitTaskModel model)
        {
            var input = "input";
            var expectedOutput = "input";
            var output = await jdoodleService.CompileCodeAsync(model.SolutionCode, input).ConfigureAwait(false);

            return new OkResult();
        }
    }
}
