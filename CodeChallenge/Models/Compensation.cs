using System;

namespace CodeChallenge.Models
{
    public class Compensation
    {
        public string CompensationID { get; set; }
        public Employee CompensatedEmployee { get; set; }
        public int Salary { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
