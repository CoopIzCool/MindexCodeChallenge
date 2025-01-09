using CodeChallenge.Models;
using CodeChallenge.Repositories;

namespace CodeChallenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IReportingStructureRepository _reportingStructureRepository;

        public ReportingStructureService(IReportingStructureRepository reportingStructureRepository)
        {
            _reportingStructureRepository = reportingStructureRepository;
        }

        public ReportingStructure GetStructureById(string id)
        {
            return _reportingStructureRepository.GetStructureById(id);
        }
    }
}
