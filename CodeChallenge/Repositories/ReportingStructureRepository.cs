using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CodeChallenge.Data;


namespace CodeChallenge.Repositories
{
    public class ReportingStructureRepository : IReportingStructureRepository
    {
        private readonly EmployeeContext _employeeContext;

        public ReportingStructureRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public ReportingStructure GetStructureById(string id)
        {
            var employeeRef = _employeeContext.Employees.Include(e => e.DirectReports).ToList().FirstOrDefault(e => e.EmployeeId == id);

            int totalReportsFromEmployee = GetNumberOfReportingEmployees(employeeRef);

            return new ReportingStructure
            {
                Employee = employeeRef,
                NumberOfReports = totalReportsFromEmployee
            };
        }

        public int GetNumberOfReportingEmployees(Employee employee)
        {
            //Null catch if theres no reports
            if(employee.DirectReports == null)
            {
                return 0;
            }
            int reportingCount = employee.DirectReports.Count;

            //recursively call each reporting employee to return how many report to them
            foreach (var reportingEmployee in employee.DirectReports)
            {
                reportingCount += GetNumberOfReportingEmployees(reportingEmployee);
            }

            return reportingCount;
        }

    }
}
