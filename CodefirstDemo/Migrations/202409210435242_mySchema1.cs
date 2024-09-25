namespace CodefirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mySchema1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.pizzatbl", "pizzatype");
        }
        
        public override void Down()
        {
            AddColumn("dbo.pizzatbl", "pizzatype", c => c.String(maxLength: 50, unicode: false));
        }
    }
}
