namespace Afore2020.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zdjecia1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ZdjeciaKarty",
                c => new
                    {
                        ZdjeciaKartyID = c.Int(nullable: false, identity: true),
                        ZdjeciaKartyNazwa = c.String(maxLength: 70),
                        ZdjeciaKartyOpis = c.String(maxLength: 70),
                        ZdjeciaKartyZdjecie = c.Binary(),
                        ZdjeciaKartyDataTworzenia = c.DateTime(nullable: false),
                        ZdjeciaKartyOperatorTw = c.String(maxLength: 70),
                        ZdjeciaKartyDatamodyfikacji = c.DateTime(nullable: false),
                        ZdjeciaKartyOperatorMd = c.String(maxLength: 70),
                    })
                .PrimaryKey(t => t.ZdjeciaKartyID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ZdjeciaKarty");
        }
    }
}
