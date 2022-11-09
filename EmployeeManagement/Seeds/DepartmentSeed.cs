using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.DataAccess;
using EmployeeManagement.Models;
using EmployeeManagement.Seeds.Bases;

namespace EmployeeManagement.Seeds
{
    internal class DepartmentSeed : EmployeeManagementDbSeedBase
    {
        public override void Execute(EmployeeManagementDbContext context)
        {
            context.Departments.AddOrUpdate(
                e => e.Id,
                new Department() { Uid = Guid.NewGuid(), Name = "総務", UpdateAt = DateTime.Now },
                new Department() { Uid = Guid.NewGuid(), Name = "人事", UpdateAt = DateTime.Now },
                new Department() { Uid = Guid.NewGuid(), Name = "経理", UpdateAt = DateTime.Now },
                new Department() { Uid = Guid.NewGuid(), Name = "営業", UpdateAt = DateTime.Now },
                new Department() { Uid = Guid.NewGuid(), Name = "システム", UpdateAt = DateTime.Now });
        }
    }
}
