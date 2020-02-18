namespace Afore2020.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class akartawyjazdu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AKartaWyjazdu",
                c => new
                    {
                        AKartaWyjazduID = c.Int(nullable: false, identity: true),
                        AKartaWyjazduDataWizyty = c.DateTime(nullable: false),
                        AKartaWyjazduNrWyjazdu = c.String(nullable: false, maxLength: 20),
                        ASerwisanciID = c.Int(nullable: false),
                        AKartaWyjazduImieNazwisko = c.String(nullable: false, maxLength: 100),
                        AMiejscowoscID = c.Int(nullable: false),
                        AKartaWyjazduUlicaNumerDomuLokalu = c.String(nullable: false, maxLength: 100),
                        AKartaWyjazduPoczta = c.String(nullable: false, maxLength: 60),
                        AKartaWyjazduKodPocztowy = c.String(nullable: false, maxLength: 15),
                        AWojewodztwoID = c.Int(nullable: false),
                        AKartaWyjazduTelefon = c.String(nullable: false, maxLength: 100),
                        AKartaWyjazduTelefon2 = c.String(maxLength: 100),
                        AInwerteraID = c.Int(nullable: false),
                        AKartaWyjazduNumerInwertera = c.String(nullable: false, maxLength: 16),
                        AKartaWyjazduNumerWifi = c.String(nullable: false, maxLength: 11),
                        AKartaWyjazduOnLine = c.Boolean(nullable: false),
                        AKartaWyjazduPV1 = c.Int(nullable: false),
                        AKartaWyjazduPV1LiczbaPaneli = c.Int(nullable: false),
                        AKartaWyjazduPV1Kierunek = c.String(maxLength: 250),
                        AKartaWyjazduPV2 = c.Int(nullable: false),
                        AKartaWyjazduPV2LiczbaPaneli = c.Int(nullable: false),
                        AKartaWyjazduPV2Kierunek = c.String(maxLength: 250),
                        AKartaWyjazduPV3 = c.Int(nullable: false),
                        AKartaWyjazduPV3LiczbaPaneli = c.Int(nullable: false),
                        AKartaWyjazduPV3Kierunek = c.String(maxLength: 250),
                        AKartaWyjazduKodyBledow = c.String(maxLength: 250),
                        AKartaWyjazduSofty = c.String(maxLength: 250),
                        AKartaWyjazduNoramPanstwo = c.String(maxLength: 250),
                        AKartaWyjazduOgranicznikPrzepiecAC = c.Boolean(nullable: false),
                        AKartaWyjazduOgranicznikPrzepiecDC = c.Boolean(nullable: false),
                        AKartaWyjazduBezpiecznikAC = c.Boolean(nullable: false),
                        AKartaWyjazduBezpiecznikDC = c.Boolean(nullable: false),
                        AKartaWyjazduUziemienieInwertera = c.Boolean(nullable: false),
                        AKartaWyjazduLoginKlienta = c.String(maxLength: 250),
                        AKartaWyjazduHasloKlienta = c.String(maxLength: 250),
                        AKartaWyjazduSpostrzezenia = c.String(maxLength: 250),
                        AKartaWyjazduDzialania = c.String(maxLength: 250),
                        AKartaWyjazduDataTworzenia = c.DateTime(nullable: false),
                        AKartaWyjazduOperatorTw = c.String(maxLength: 70),
                        AKartaWyjazduDatamodyfikacji = c.DateTime(nullable: false),
                        AKartaWyjazduOperatorMd = c.String(maxLength: 70),
                        AInwertera_AInwerteryID = c.Int(),
                        AMiejscowosc_AMiastaID = c.Int(),
                    })
                .PrimaryKey(t => t.AKartaWyjazduID)
                .ForeignKey("dbo.AInwertery", t => t.AInwertera_AInwerteryID)
                .ForeignKey("dbo.AMiasta", t => t.AMiejscowosc_AMiastaID)
                .ForeignKey("dbo.AWojewodztwo", t => t.AWojewodztwoID, cascadeDelete: true)
                .ForeignKey("dbo.ASerwisanci", t => t.ASerwisanciID, cascadeDelete: true)
                .Index(t => t.ASerwisanciID)
                .Index(t => t.AWojewodztwoID)
                .Index(t => t.AInwertera_AInwerteryID)
                .Index(t => t.AMiejscowosc_AMiastaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AKartaWyjazdu", "ASerwisanciID", "dbo.ASerwisanci");
            DropForeignKey("dbo.AKartaWyjazdu", "AWojewodztwoID", "dbo.AWojewodztwo");
            DropForeignKey("dbo.AKartaWyjazdu", "AMiejscowosc_AMiastaID", "dbo.AMiasta");
            DropForeignKey("dbo.AKartaWyjazdu", "AInwertera_AInwerteryID", "dbo.AInwertery");
            DropIndex("dbo.AKartaWyjazdu", new[] { "AMiejscowosc_AMiastaID" });
            DropIndex("dbo.AKartaWyjazdu", new[] { "AInwertera_AInwerteryID" });
            DropIndex("dbo.AKartaWyjazdu", new[] { "AWojewodztwoID" });
            DropIndex("dbo.AKartaWyjazdu", new[] { "ASerwisanciID" });
            DropTable("dbo.AKartaWyjazdu");
        }
    }
}
