using Afore2020.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Afore2020.DAL
{
    public class OgniwoContext:DbContext
    {
        public OgniwoContext() : base("OgniwoBaza")
        {
        }


        //usowa s na koncach wtorzonych tabelach
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        public DbSet<Wojewodztwo> owojewodztwos { get; set; }
        public DbSet<Miejscowosc> omiejscooscs { get; set; }

    }
}
