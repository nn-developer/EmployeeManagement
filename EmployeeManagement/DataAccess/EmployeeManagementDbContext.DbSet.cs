﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.DataAccess
{
    public partial class EmployeeManagementDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
