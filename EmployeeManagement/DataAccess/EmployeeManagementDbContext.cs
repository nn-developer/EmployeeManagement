using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.DataAccess
{
    public partial class EmployeeManagementDbContext : DbContext
    {
        private static readonly string WPF_SAMPLE_DB__Directory_Name = "Databases";

        private static readonly string WPF_SAMPLE_DB_FILE_NAME = "EmployeeManagementDb.sqlite";

        private static string s_migrationSqlitePath;

        static EmployeeManagementDbContext()
        {
            //// デバッグ実行用コード
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            var exeDir = AppDomain.CurrentDomain.BaseDirectory;
            var exeDirInfo = new DirectoryInfo(exeDir);
            var projectDir = exeDirInfo.Parent.Parent.FullName;
            s_migrationSqlitePath = $@"{projectDir}\{WPF_SAMPLE_DB__Directory_Name}\{WPF_SAMPLE_DB_FILE_NAME}";
        }

        public EmployeeManagementDbContext() : base(new SQLiteConnection($"DATA Source={s_migrationSqlitePath}; BinaryGUID=False;"), false)
        { }

        public EmployeeManagementDbContext(DbConnection connection) : base(connection, true)
        { }
    }
}
