using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services;
using CodeChallenge.Models;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/compensation")]
    public class CompensationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        [HttpPost]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received request to create compensation for '{compensation.CompensationID}'");

            _compensationService.Create(compensation);

            return CreatedAtAction("getCompensationById", new { id = compensation.CompensationID }, compensation);
        }

        [HttpGet("{id}",Name = "getCompensationByEmployeeId")]
        public IActionResult GetCompensationById(string id)
        {
            _logger.LogDebug($"Received request to get compensation for '{id}'");

            Compensation compensation = _compensationService.GetById(id);

            if(compensation == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(compensation);
            }
        }
    }
}
