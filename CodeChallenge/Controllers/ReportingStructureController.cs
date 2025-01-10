using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services;
using CodeChallenge.Models;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/reporting-structure")]
    public class ReportingStructureController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IReportingStructureService _reportingStructureService;

        public ReportingStructureController(ILogger<ReportingStructureController> logger, IReportingStructureService reportingStructureService)
        {
            _logger = logger;
            _reportingStructureService = reportingStructureService;
        }

        [HttpGet("{id}", Name = "getByEmployeeId")]
        public IActionResult GetByEmployeeId(string id)
        {
            _logger.LogDebug($"Received get report structure request for '{id}'");

            ReportingStructure reportStructure = _reportingStructureService.GetStructureById(id);

            if (reportStructure == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(reportStructure);
            }
        }
    }
}
