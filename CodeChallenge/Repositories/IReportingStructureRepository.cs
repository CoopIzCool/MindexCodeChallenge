using CodeChallenge.Models;

namespace CodeChallenge.Repositories
{
    public interface IReportingStructureRepository
    {
        ReportingStructure GetStructureById(string id);
    }
}
