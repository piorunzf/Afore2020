namespace Afore2020.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class akartawyjazdu1 : DbMigration
    {
       
        
        public override void Down()
        {
            AddColumn("dbo.AKartaWyjazdu", "AInwerteraID", c => c.Int(nullable: false));
            AddColumn("dbo.AKartaWyjazdu", "AMiejscowoscID", c => c.Int(nullable: false));
            DropForeignKey("dbo.AKartaWyjazdu", "AMiastaID", "dbo.AMiasta");
            DropForeignKey("dbo.AKartaWyjazdu", "AInwerteryID", "dbo.AInwertery");
            DropIndex("dbo.AKartaWyjazdu", new[] { "AInwerteryID" });
            DropIndex("dbo.AKartaWyjazdu", new[] { "AMiastaID" });
            AlterColumn("dbo.AKartaWyjazdu", "AMiastaID", c => c.Int());
            AlterColumn("dbo.AKartaWyjazdu", "AInwerteryID", c => c.Int());
            RenameColumn(table: "dbo.AKartaWyjazdu", name: "AMiastaID", newName: "AMiejscowosc_AMiastaID");
            RenameColumn(table: "dbo.AKartaWyjazdu", name: "AInwerteryID", newName: "AInwertera_AInwerteryID");
            CreateIndex("dbo.AKartaWyjazdu", "AMiejscowosc_AMiastaID");
            CreateIndex("dbo.AKartaWyjazdu", "AInwertera_AInwerteryID");
            AddForeignKey("dbo.AKartaWyjazdu", "AMiejscowosc_AMiastaID", "dbo.AMiasta", "AMiastaID");
            AddForeignKey("dbo.AKartaWyjazdu", "AInwertera_AInwerteryID", "dbo.AInwertery", "AInwerteryID");
        }

        public override void Up()
        {
            DropForeignKey("dbo.AKartaWyjazdu", "AInwertera_AInwerteryID", "dbo.AInwertery");
            DropForeignKey("dbo.AKartaWyjazdu", "AMiejscowosc_AMiastaID", "dbo.AMiasta");
            DropIndex("dbo.AKartaWyjazdu", new[] { "AInwertera_AInwerteryID" });
            DropIndex("dbo.AKartaWyjazdu", new[] { "AMiejscowosc_AMiastaID" });
            RenameColumn(table: "dbo.AKartaWyjazdu", name: "AInwertera_AInwerteryID", newName: "AInwerteryID");
            RenameColumn(table: "dbo.AKartaWyjazdu", name: "AMiejscowosc_AMiastaID", newName: "AMiastaID");
            AlterColumn("dbo.AKartaWyjazdu", "AInwerteryID", c => c.Int(nullable: false));
            AlterColumn("dbo.AKartaWyjazdu", "AMiastaID", c => c.Int(nullable: false));
            CreateIndex("dbo.AKartaWyjazdu", "AMiastaID");
            CreateIndex("dbo.AKartaWyjazdu", "AInwerteryID");
            AddForeignKey("dbo.AKartaWyjazdu", "AInwerteryID", "dbo.AInwertery", "AInwerteryID", cascadeDelete: true);
           // AddForeignKey("dbo.AKartaWyjazdu", "AMiastaID", "dbo.AMiasta", "AMiastaID", cascadeDelete: true);
            DropColumn("dbo.AKartaWyjazdu", "AMiejscowoscID");
            DropColumn("dbo.AKartaWyjazdu", "AInwerteraID");
        }
    }
}
