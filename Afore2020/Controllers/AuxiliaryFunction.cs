using Afore2020.DAL;
using Afore2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Afore2020.Controllers
{
    public class AuxiliaryFunction
    {
        private AforeContext db = new AforeContext();
        private OgniwoContext dbOgniwo = new OgniwoContext();

        public void CopyWojewodztwa()
        {
       
        AWojewodztwo aWojewodztwo = new AWojewodztwo();

           // Wojewodztwo owojewodztwo = new Wojewodztwo();


            var woj = dbOgniwo.owojewodztwos.ToList();
            var wojA = db.AWojewodztwoes.ToList();


            woj.ForEach((item) =>
            {
                aWojewodztwo.AWojewodztwoNazwa = item.WojewodztwoNazwa;

                db.AWojewodztwoes.Add(aWojewodztwo);
                db.SaveChanges();
            });
        }

        public void CopyMiasto()
        {
            AMiasta miasta = new AMiasta();
           

            var miast = dbOgniwo.omiejscooscs.ToList();
            var miastas = db.AMiastas.ToList();


            miast.ForEach((item) =>
            {
                miasta.AMiastaNazwa = item.MiejscowoscNazwa;
                miasta.AWojewodztwoID = item.WojewodztwoID;
                db.AMiastas.Add(miasta);
                db.SaveChanges();
            });




        }


    }
}