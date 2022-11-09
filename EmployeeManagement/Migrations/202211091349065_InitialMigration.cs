namespace EmployeeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.department",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        uid = c.Guid(nullable: false),
                        name = c.String(nullable: false, maxLength: 50),
                        update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.employee",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        uid = c.Guid(nullable: false),
                        first_name = c.String(nullable: false, maxLength: 50),
                        family_name = c.String(nullable: false, maxLength: 50),
                        birthday = c.DateTime(nullable: false),
                        gender = c.Int(nullable: false),
                        mail_address = c.String(maxLength: 50),
                        department_uid = c.Guid(nullable: false),
                        remark = c.String(maxLength: 1000),
                        update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        uid = c.Guid(nullable: false),
                        user_id = c.String(nullable: false, maxLength: 50),
                        password = c.String(nullable: false, maxLength: 50),
                        remark = c.String(maxLength: 1000),
                        update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.user");
            DropTable("dbo.employee");
            DropTable("dbo.department");
        }
    }
}
