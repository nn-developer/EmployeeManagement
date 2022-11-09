namespace EmployeeManagement.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SQLite.EF6.Migrations;
    using System.Linq;
    using EmployeeManagement.DataAccess;
    using EmployeeManagement.Models;
    using EmployeeManagement.Seeds;
    using EmployeeManagement.Seeds.Bases;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeManagementDbContext>
    {
        /// <summary>
        /// 実行するSeedリスト
        /// </summary>
        private List<EmployeeManagementDbSeedBase> Seeds { get; set; } = new List<EmployeeManagementDbSeedBase>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());

            // 実行するSeedを追加
            this.Seeds.Add(new DepartmentSeed());
            this.Seeds.Add(new EmployeeSeed());
            this.Seeds.Add(new UserSeed());
        }

        /// <summary>
        /// Migration実行後のSeed処理
        /// </summary>
        /// <param name="context">対象のデータコンテキスト</param>
        protected override void Seed(EmployeeManagementDbContext context)
        {
            //// デバッグ実行用コード
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            // 追加したSeedを実行
            this.Seeds.ForEach(s =>
            {
                s.Execute(context);
                context.SaveChanges();
            });
        }
    }
}
