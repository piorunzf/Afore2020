namespace Afore2020.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AOdbiorca2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AOdbiorcy", "AOdbiorcyUlicaNumerDomuLokalu", c => c.String(maxLength: 100));
            AlterColumn("dbo.AOdbiorcy", "AOdbiorcyNIP", c => c.String(maxLength: 20));
            AlterColumn("dbo.AOdbiorcy", "AOdbiorcyPoczta", c => c.String(maxLength: 60));
            AlterColumn("dbo.AOdbiorcy", "AOdbiorcyKodPocztowy", c => c.String(maxLength: 15));
            AlterColumn("dbo.AOdbiorcy", "AOdbiorcyTelefon", c => c.String(maxLength: 100));
            AlterColumn("dbo.AOdbiorcy", "AOdbiorcaEmail", c => c.String());
            DropColumn("dbo.AOdbiorcy", "AKartaWyjazduUlicaNumerDomuLokalu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AOdbiorcy", "AKartaWyjazduUlicaNumerDomuLokalu", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.AOdbiorcy", "AOdbiorcaEmail", c => c.String(nullable: false));
            AlterColumn("dbo.AOdbiorcy", "AOdbiorcyTelefon", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.AOdbiorcy", "AOdbiorcyKodPocztowy", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.AOdbiorcy", "AOdbiorcyPoczta", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.AOdbiorcy", "AOdbiorcyNIP", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.AOdbiorcy", "AOdbiorcyUlicaNumerDomuLokalu");
        }
    }
}
