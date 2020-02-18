using Afore2020.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Afore2020.DAL
{
    public class AforeContext : DbContext
{
        public AforeContext() :base("AforeBaza")
            {
            }

        static AforeContext()
        {
            Database.SetInitializer<AforeContext>(new AforeInicjalizacja());
        }

        //usowa s na koncach wtorzonych tabelach
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        public DbSet<AWojewodztwo> AWojewodztwoes { get; set; }

        public DbSet<AMiasta> AMiastas { get; set; }

        public DbSet<ASerwisanci> ASerwisancis { get; set; }

        public DbSet<AInwertery> AInwerteries { get; set; }

        public DbSet<AKartaWyjazdu> AKartaWyjazdus { get; set; }

        public DbSet<ZdjeciaKarty> ZdjeciaKarties { get; set; }

        public System.Data.Entity.DbSet<Afore2020.Models.AOdbiorcy> AOdbiorcies { get; set; }

       
    }
}