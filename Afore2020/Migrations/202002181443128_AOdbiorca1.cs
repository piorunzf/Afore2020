namespace Afore2020.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AOdbiorca1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AOdbiorcy",
                c => new
                    {
                        AOdbiorcyID = c.Int(nullable: false, identity: true),
                        AOdbiorcyKod = c.String(nullable: false, maxLength: 70),
                        AOdbiorcyNazwa = c.String(nullable: false, maxLength: 200),
                        AOdbiorcyNIP = c.String(nullable: false, maxLength: 20),
                        AMiastaID = c.Int(nullable: false),
                        AKartaWyjazduUlicaNumerDomuLokalu = c.String(nullable: false, maxLength: 100),
                        AOdbiorcyPoczta = c.String(nullable: false, maxLength: 60),
                        AOdbiorcyKodPocztowy = c.String(nullable: false, maxLength: 15),
                        AWojewodztwoID = c.Int(nullable: false),
                        AOdbiorcyTelefon = c.String(nullable: false, maxLength: 100),
                        AOdbiorcaEmail = c.String(nullable: false),
                        AOdborcaUwagi = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.AOdbiorcyID)
                .ForeignKey("dbo.AMiasta", t => t.AMiastaID, cascadeDelete: true)
                .Index(t => t.AMiastaID)
                .Index(t => t.AWojewodztwoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AOdbiorcy", "AWojewodztwoID", "dbo.AWojewodztwo");
            DropForeignKey("dbo.AOdbiorcy", "AMiastaID", "dbo.AMiasta");
            DropIndex("dbo.AOdbiorcy", new[] { "AWojewodztwoID" });
            DropIndex("dbo.AOdbiorcy", new[] { "AMiastaID" });
            DropTable("dbo.AOdbiorcy");
        }
    }
}
