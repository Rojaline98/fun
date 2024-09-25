namespace CodefirstAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mySchema1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.depttbl",
                c => new
                    {
                        Deptid = c.Int(nullable: false),
                        DepartmentName = c.String(maxLength: 20, unicode: false),
                        Manager = c.String(maxLength: 20, unicode: false),
                        DepartmentEdit = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Deptid);
            
            CreateTable(
                "dbo.emptbl",
                c => new
                    {
                        Empid = c.String(nullable: false, maxLength: 10, unicode: false),
                        EmpName = c.String(maxLength: 20, unicode: false),
                        Salary = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Deptid_Deptid = c.Int(),
                    })
                .PrimaryKey(t => t.Empid)
                .ForeignKey("dbo.depttbl", t => t.Deptid_Deptid)
                .Index(t => t.Deptid_Deptid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.emptbl", "Deptid_Deptid", "dbo.depttbl");
            DropIndex("dbo.emptbl", new[] { "Deptid_Deptid" });
            DropTable("dbo.emptbl");
            DropTable("dbo.depttbl");
        }
    }
}
