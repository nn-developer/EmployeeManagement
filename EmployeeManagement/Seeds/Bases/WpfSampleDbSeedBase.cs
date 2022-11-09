using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.DataAccess;

namespace EmployeeManagement.Seeds.Bases
{
    /// <summary>
    /// Seedの基本クラス
    /// </summary>
    public abstract class EmployeeManagementDbSeedBase
    {
        public abstract void Execute(EmployeeManagementDbContext context);
    }
}
