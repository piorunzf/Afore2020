namespace Afore2020.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serwisanci1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ASerwisanci",
                c => new
                    {
                        ASerwisanciID = c.Int(nullable: false, identity: true),
                        ASerwisanciImię = c.String(nullable: false, maxLength: 70),
                        ASerwisanciNazwisko = c.String(nullable: false, maxLength: 70),
                        ASerwisanciTelefon = c.String(nullable: false, maxLength: 70),
                        ASerwisanciOpis = c.String(maxLength: 250),
                        ASerwisanciAktywny = c.Boolean(nullable: false),
                        ASerwisanciDataTworzenia = c.DateTime(nullable: false),
                        ASerwisanciOperatorTw = c.String(maxLength: 70),
                        ASerwisanciDatamodyfikacji = c.DateTime(nullable: false),
                        ASerwisanciOperatorMd = c.String(maxLength: 70),
                    })
                .PrimaryKey(t => t.ASerwisanciID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ASerwisanci");
        }
    }
}
