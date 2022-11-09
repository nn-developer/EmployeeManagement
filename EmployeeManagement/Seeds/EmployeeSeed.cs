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
    internal class EmployeeSeed : EmployeeManagementDbSeedBase
    {
        public override void Execute(EmployeeManagementDbContext context)
        {
            var departmentQueue = new Queue<Department>();
            for (int i = 0; i < 3; i++)
            {
                foreach (var department in context.Departments)
                {
                    departmentQueue.Enqueue(department);
                }
            }

            var gen = new Random();
            DateTime RandomDay()
            {
                var lowerLimitDate = new DateTime(1970, 1, 1);
                var upperLimitDate = new DateTime(2000, 1, 1);
                var range = (upperLimitDate - lowerLimitDate).Days;
                var result = lowerLimitDate.AddDays(gen.Next(range));
                return result;
            }

            context.Employees.AddOrUpdate(
                e => e.Id,
                new Employee() { Uid = Guid.NewGuid(), FirstName = "一朗", FamilyName = "佐藤", Birthday = RandomDay(), Gender = 0, MailAddress = "", DepartmentUid = departmentQueue.Dequeue().Uid, UpdateAt = DateTime.Now },
                new Employee() { Uid = Guid.NewGuid(), FirstName = "智子", FamilyName = "鈴木", Birthday = RandomDay(), Gender = 1, MailAddress = "", DepartmentUid = departmentQueue.Dequeue().Uid, UpdateAt = DateTime.Now },
                new Employee() { Uid = Guid.NewGuid(), FirstName = "太郎", FamilyName = "高橋", Birthday = RandomDay(), Gender = 0, MailAddress = "", DepartmentUid = departmentQueue.Dequeue().Uid, UpdateAt = DateTime.Now },
                new Employee() { Uid = Guid.NewGuid(), FirstName = "真奈美", FamilyName = "田中", Birthday = RandomDay(), Gender = 1, MailAddress = "", DepartmentUid = departmentQueue.Dequeue().Uid, UpdateAt = DateTime.Now },
                new Employee() { Uid = Guid.NewGuid(), FirstName = "勇樹", FamilyName = "伊藤", Birthday = RandomDay(), Gender = 0, MailAddress = "", DepartmentUid = departmentQueue.Dequeue().Uid, UpdateAt = DateTime.Now },
                new Employee() { Uid = Guid.NewGuid(), FirstName = "愛里", FamilyName = "渡辺", Birthday = RandomDay(), Gender = 1, MailAddress = "", DepartmentUid = departmentQueue.Dequeue().Uid, UpdateAt = DateTime.Now },
                new Employee() { Uid = Guid.NewGuid(), FirstName = "亮太", FamilyName = "山本", Birthday = RandomDay(), Gender = 0, MailAddress = "", DepartmentUid = departmentQueue.Dequeue().Uid, UpdateAt = DateTime.Now },
                new Employee() { Uid = Guid.NewGuid(), FirstName = "麻由美", FamilyName = "中村", Birthday = RandomDay(), Gender = 1, MailAddress = "", DepartmentUid = departmentQueue.Dequeue().Uid, UpdateAt = DateTime.Now },
                new Employee() { Uid = Guid.NewGuid(), FirstName = "学", FamilyName = "小林", Birthday = RandomDay(), Gender = 0, MailAddress = "", DepartmentUid = departmentQueue.Dequeue().Uid, UpdateAt = DateTime.Now },
                new Employee() { Uid = Guid.NewGuid(), FirstName = "愛", FamilyName = "平", Birthday = RandomDay(), Gender = 1, MailAddress = "", DepartmentUid = departmentQueue.Dequeue().Uid, UpdateAt = DateTime.Now },
                new Employee() { Uid = Guid.NewGuid(), FirstName = "健太", FamilyName = "吉田", Birthday = RandomDay(), Gender = 0, MailAddress = "", DepartmentUid = departmentQueue.Dequeue().Uid, UpdateAt = DateTime.Now },
                new Employee() { Uid = Guid.NewGuid(), FirstName = "由美", FamilyName = "山田", Birthday = RandomDay(), Gender = 1, MailAddress = "", DepartmentUid = departmentQueue.Dequeue().Uid, UpdateAt = DateTime.Now },
                new Employee() { Uid = Guid.NewGuid(), FirstName = "孝太郎", FamilyName = "佐々木", Birthday = RandomDay(), Gender = 0, MailAddress = "", DepartmentUid = departmentQueue.Dequeue().Uid, UpdateAt = DateTime.Now });
        }
    }
}
