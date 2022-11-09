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
    internal class UserSeed : EmployeeManagementDbSeedBase
    {
        public override void Execute(EmployeeManagementDbContext context)
        {
            context.Users.AddOrUpdate(
                e => e.Id,
                new User() { Uid = Guid.NewGuid(), UserId = "admin001", Password = "admin001", UpdateAt = DateTime.Now },
                new User() { Uid = Guid.NewGuid(), UserId = "admin002", Password = "admin002", UpdateAt = DateTime.Now },
                new User() { Uid = Guid.NewGuid(), UserId = "admin003", Password = "admin003", UpdateAt = DateTime.Now }
                );
        }
    }
}
