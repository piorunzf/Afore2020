using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Afore2020.Migrations;

namespace Afore2020.DAL
{
    public class AforeInicjalizacja : MigrateDatabaseToLatestVersion<AforeContext, Configuration>
    {
            /*
            protected override void Seed(OgniwoContext context)
            {
                SeedOgniwoData(context);
                base.Seed(context);
            }
            */
            private void SeedOgniwoData(AforeContext context)
            {
                /*
                var owyroby = new List<OWyroby>

                {
                    new OWyroby()  {OWyrobyID=1, OWyrobyNazwaWyrobu ="S6WC 16kw"}
                                };
                owyroby.ForEach(k => context.OWybory.Add(k));
                context.SaveChanges();
                */

            }

        }
}