namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "City");
        }
    }
}
