namespace Afore2020.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inwertery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AInwertery",
                c => new
                    {
                        AInwerteryID = c.Int(nullable: false, identity: true),
                        AInwerteryModelInwentera = c.String(nullable: false, maxLength: 70),
                        AInwerteryOpis = c.String(maxLength: 250),
                        AInwerteryAktywny = c.Boolean(nullable: false),
                        AInwerteryDataTworzenia = c.DateTime(nullable: false),
                        AInwerteryiOperatorTw = c.String(maxLength: 70),
                        AInwerteryDatamodyfikacji = c.DateTime(nullable: false),
                        AInwerteryOperatorMd = c.String(maxLength: 70),
                    })
                .PrimaryKey(t => t.AInwerteryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AInwertery");
        }
    }
}
