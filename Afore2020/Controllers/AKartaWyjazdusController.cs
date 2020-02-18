using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Afore2020.DAL;
using Afore2020.Models;

namespace Afore2020.Controllers
{
    [Authorize]
    public class AKartaWyjazdusController : Controller
    {
        private AforeContext db = new AforeContext();
       



        // GET: AKartaWyjazdus
        public ActionResult Index()
        {
            var aKartaWyjazdus = db.AKartaWyjazdus.Include(a => a.AInwertera).Include(a => a.AMiejscowosc).Include(a => a.ASerwisanci).Include(a => a.AWojewodztwo);
            return View(aKartaWyjazdus.ToList());
        }

        // GET: AKartaWyjazdus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AKartaWyjazdu aKartaWyjazdu = db.AKartaWyjazdus.Find(id);
            if (aKartaWyjazdu == null)
            {
                return HttpNotFound();
            }
            return View(aKartaWyjazdu);
        }

        // GET: AKartaWyjazdus/Create
        public ActionResult Create()
        {
            ViewBag.AInwerteryID = new SelectList(db.AInwerteries, "AInwerteryID", "AInwerteryModelInwentera");
            ViewBag.AMiastaID = new SelectList(db.AMiastas, "AMiastaID", "AMiastaNazwa");
            ViewBag.ASerwisanciID = new SelectList(db.ASerwisancis, "ASerwisanciID", "ASerwisanciImię");
            ViewBag.AWojewodztwoID = new SelectList(db.AWojewodztwoes, "AWojewodztwoID", "AWojewodztwoNazwa");
            AKartaWyjazdu nKartaWyjazdu = new AKartaWyjazdu();
            nKartaWyjazdu.AKartaWyjazduDatamodyfikacji = DateTime.Now;
            nKartaWyjazdu.AKartaWyjazduDataTworzenia = DateTime.Now;
            nKartaWyjazdu.AKartaWyjazduDataWizyty = DateTime.Now;
            nKartaWyjazdu.AKartaWyjazduOperatorMd = User.Identity.Name;
            nKartaWyjazdu.AKartaWyjazduOperatorTw = User.Identity.Name;



            return View(nKartaWyjazdu);
        }

        // POST: AKartaWyjazdus/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AKartaWyjazduID,AKartaWyjazduDataWizyty,AKartaWyjazduNrWyjazdu,ASerwisanciID,AKartaWyjazduImieNazwisko,AMiastaID,AKartaWyjazduUlicaNumerDomuLokalu,AKartaWyjazduPoczta,AKartaWyjazduKodPocztowy,AWojewodztwoID,AKartaWyjazduTelefon,AKartaWyjazduTelefon2,AInwerteryID,AKartaWyjazduNumerInwertera,AKartaWyjazduNumerWifi,AKartaWyjazduOnLine,AKartaWyjazduPV1,AKartaWyjazduPV1LiczbaPaneli,AKartaWyjazduPV1Kierunek,AKartaWyjazduPV2,AKartaWyjazduPV2LiczbaPaneli,AKartaWyjazduPV2Kierunek,AKartaWyjazduPV3,AKartaWyjazduPV3LiczbaPaneli,AKartaWyjazduPV3Kierunek,AKartaWyjazduKodyBledow,AKartaWyjazduSofty,AKartaWyjazduNoramPanstwo,AKartaWyjazduOgranicznikPrzepiecAC,AKartaWyjazduOgranicznikPrzepiecDC,AKartaWyjazduBezpiecznikAC,AKartaWyjazduBezpiecznikDC,AKartaWyjazduUziemienieInwertera,AKartaWyjazduLoginKlienta,AKartaWyjazduHasloKlienta,AKartaWyjazduSpostrzezenia,AKartaWyjazduDzialania,AKartaWyjazduDataTworzenia,AKartaWyjazduOperatorTw,AKartaWyjazduDatamodyfikacji,AKartaWyjazduOperatorMd")] AKartaWyjazdu aKartaWyjazdu)
        {
            if (ModelState.IsValid)
            {
                db.AKartaWyjazdus.Add(aKartaWyjazdu);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AInwerteryID = new SelectList(db.AInwerteries, "AInwerteryID", "AInwerteryModelInwentera", aKartaWyjazdu.AInwerteryID);
            ViewBag.AMiastaID = new SelectList(db.AMiastas, "AMiastaID", "AMiastaNazwa", aKartaWyjazdu.AMiastaID);
            ViewBag.ASerwisanciID = new SelectList(db.ASerwisancis, "ASerwisanciID", "ASerwisanciImię", aKartaWyjazdu.ASerwisanciID);
            ViewBag.AWojewodztwoID = new SelectList(db.AWojewodztwoes, "AWojewodztwoID", "AWojewodztwoNazwa", aKartaWyjazdu.AWojewodztwoID);
            return View(aKartaWyjazdu);
        }

        // GET: AKartaWyjazdus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AKartaWyjazdu aKartaWyjazdu = db.AKartaWyjazdus.Find(id);
            if (aKartaWyjazdu == null)
            {
                return HttpNotFound();
            }
           
            ViewBag.AInwerteryID = new SelectList(db.AInwerteries, "AInwerteryID", "AInwerteryModelInwentera", aKartaWyjazdu.AInwerteryID);
            ViewBag.AMiastaID = new SelectList(db.AMiastas, "AMiastaID", "AMiastaNazwa", aKartaWyjazdu.AMiastaID);
            ViewBag.ASerwisanciID = new SelectList(db.ASerwisancis, "ASerwisanciID", "ASerwisanciImię", aKartaWyjazdu.ASerwisanciID);
            ViewBag.AWojewodztwoID = new SelectList(db.AWojewodztwoes, "AWojewodztwoID", "AWojewodztwoNazwa", aKartaWyjazdu.AWojewodztwoID);
            return View(aKartaWyjazdu);
        }

        // POST: AKartaWyjazdus/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AKartaWyjazduID,AKartaWyjazduDataWizyty,AKartaWyjazduNrWyjazdu,ASerwisanciID,AKartaWyjazduImieNazwisko,AMiastaID,AKartaWyjazduUlicaNumerDomuLokalu,AKartaWyjazduPoczta,AKartaWyjazduKodPocztowy,AWojewodztwoID,AKartaWyjazduTelefon,AKartaWyjazduTelefon2,AInwerteryID,AKartaWyjazduNumerInwertera,AKartaWyjazduNumerWifi,AKartaWyjazduOnLine,AKartaWyjazduPV1,AKartaWyjazduPV1LiczbaPaneli,AKartaWyjazduPV1Kierunek,AKartaWyjazduPV2,AKartaWyjazduPV2LiczbaPaneli,AKartaWyjazduPV2Kierunek,AKartaWyjazduPV3,AKartaWyjazduPV3LiczbaPaneli,AKartaWyjazduPV3Kierunek,AKartaWyjazduKodyBledow,AKartaWyjazduSofty,AKartaWyjazduNoramPanstwo,AKartaWyjazduOgranicznikPrzepiecAC,AKartaWyjazduOgranicznikPrzepiecDC,AKartaWyjazduBezpiecznikAC,AKartaWyjazduBezpiecznikDC,AKartaWyjazduUziemienieInwertera,AKartaWyjazduLoginKlienta,AKartaWyjazduHasloKlienta,AKartaWyjazduSpostrzezenia,AKartaWyjazduDzialania,AKartaWyjazduDataTworzenia,AKartaWyjazduOperatorTw,AKartaWyjazduDatamodyfikacji,AKartaWyjazduOperatorMd")] AKartaWyjazdu aKartaWyjazdu)
        {
            if (ModelState.IsValid)
            {
                //aKartaWyjazdu.AKartaWyjazduDatamodyfikacji = aa;
                db.Entry(aKartaWyjazdu).State = EntityState.Modified;
                aKartaWyjazdu.AKartaWyjazduDatamodyfikacji = DateTime.Now;
                aKartaWyjazdu.AKartaWyjazduOperatorMd = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.AInwerteryID = new SelectList(db.AInwerteries, "AInwerteryID", "AInwerteryModelInwentera", aKartaWyjazdu.AInwerteryID);
            ViewBag.AMiastaID = new SelectList(db.AMiastas, "AMiastaID", "AMiastaNazwa", aKartaWyjazdu.AMiastaID);
            ViewBag.ASerwisanciID = new SelectList(db.ASerwisancis, "ASerwisanciID", "ASerwisanciImię", aKartaWyjazdu.ASerwisanciID);
            ViewBag.AWojewodztwoID = new SelectList(db.AWojewodztwoes, "AWojewodztwoID", "AWojewodztwoNazwa", aKartaWyjazdu.AWojewodztwoID);
            return View(aKartaWyjazdu);
        }

        // GET: AKartaWyjazdus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AKartaWyjazdu aKartaWyjazdu = db.AKartaWyjazdus.Find(id);
            if (aKartaWyjazdu == null)
            {
                return HttpNotFound();
            }
            return View(aKartaWyjazdu);
        }

        // POST: AKartaWyjazdus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AKartaWyjazdu aKartaWyjazdu = db.AKartaWyjazdus.Find(id);
            db.AKartaWyjazdus.Remove(aKartaWyjazdu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
