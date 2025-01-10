using CodeChallenge.Data;
using CodeChallenge.Models;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace CodeChallenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly EmployeeContext _employeeContext;

        public CompensationRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public Compensation Add(Compensation compensation)
        {
            compensation.CompensationID = Guid.NewGuid().ToString();
            //To resolve issue of duplicate keys if an employee reference is created. Instead we're storing the existing employee that exists in the context
            compensation.CompensatedEmployee = _employeeContext.Employees.FirstOrDefault(e => e.EmployeeId == compensation.CompensatedEmployee.EmployeeId);
            _employeeContext.Compensations.Add(compensation);
            return compensation;
        }

        public Compensation GetById(string id)
        {
            //Eagerly loaded because employees weren't loaded properly
            return _employeeContext.Compensations.Include(c => c.CompensatedEmployee).FirstOrDefault(comp => comp.CompensatedEmployee.EmployeeId == id);
        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }
    }
}
