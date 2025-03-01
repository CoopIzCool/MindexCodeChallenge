﻿using CodeChallenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        //Added DBSet to exist in Persistance
        public DbSet<Compensation> Compensations { get; set; }
    }
}
