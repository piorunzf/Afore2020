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
    public class AOdbiorciesController : Controller
    {
        private AforeContext db = new AforeContext();

        // GET: AOdbiorcies
        public ActionResult Index()
        {
            var aOdbiorcies = db.AOdbiorcies.Include(a => a.AMiejscowosc).Include(a => a.AWojewodztwo);
            return View(aOdbiorcies.ToList());
        }

        // GET: AOdbiorcies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AOdbiorcy aOdbiorcy = db.AOdbiorcies.Find(id);
            if (aOdbiorcy == null)
            {
                return HttpNotFound();
            }
            return View(aOdbiorcy);
        }

        // GET: AOdbiorcies/Create
        public ActionResult Create()
        {
            ViewBag.AMiastaID = new SelectList(db.AMiastas, "AMiastaID", "AMiastaNazwa");
            ViewBag.AWojewodztwoID = new SelectList(db.AWojewodztwoes, "AWojewodztwoID", "AWojewodztwoNazwa");
            return View();
        }

        // POST: AOdbiorcies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AOdbiorcyID,AOdbiorcyKod,AOdbiorcyNazwa,AOdbiorcyNIP,AMiastaID,AKartaWyjazduUlicaNumerDomuLokalu,AOdbiorcyPoczta,AOdbiorcyKodPocztowy,AWojewodztwoID,AOdbiorcyTelefon,AOdbiorcaEmail,AOdborcaUwagi")] AOdbiorcy aOdbiorcy)
        {
            if (ModelState.IsValid)
            {
                db.AOdbiorcies.Add(aOdbiorcy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMiastaID = new SelectList(db.AMiastas, "AMiastaID", "AMiastaNazwa", aOdbiorcy.AMiastaID);
            ViewBag.AWojewodztwoID = new SelectList(db.AWojewodztwoes, "AWojewodztwoID", "AWojewodztwoNazwa", aOdbiorcy.AWojewodztwoID);
            return View(aOdbiorcy);
        }

        // GET: AOdbiorcies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AOdbiorcy aOdbiorcy = db.AOdbiorcies.Find(id);
            if (aOdbiorcy == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMiastaID = new SelectList(db.AMiastas, "AMiastaID", "AMiastaNazwa", aOdbiorcy.AMiastaID);
            ViewBag.AWojewodztwoID = new SelectList(db.AWojewodztwoes, "AWojewodztwoID", "AWojewodztwoNazwa", aOdbiorcy.AWojewodztwoID);
            return View(aOdbiorcy);
        }

        // POST: AOdbiorcies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AOdbiorcyID,AOdbiorcyKod,AOdbiorcyNazwa,AOdbiorcyNIP,AMiastaID,AKartaWyjazduUlicaNumerDomuLokalu,AOdbiorcyPoczta,AOdbiorcyKodPocztowy,AWojewodztwoID,AOdbiorcyTelefon,AOdbiorcaEmail,AOdborcaUwagi")] AOdbiorcy aOdbiorcy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aOdbiorcy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMiastaID = new SelectList(db.AMiastas, "AMiastaID", "AMiastaNazwa", aOdbiorcy.AMiastaID);
            ViewBag.AWojewodztwoID = new SelectList(db.AWojewodztwoes, "AWojewodztwoID", "AWojewodztwoNazwa", aOdbiorcy.AWojewodztwoID);
            return View(aOdbiorcy);
        }

        // GET: AOdbiorcies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AOdbiorcy aOdbiorcy = db.AOdbiorcies.Find(id);
            if (aOdbiorcy == null)
            {
                return HttpNotFound();
            }
            return View(aOdbiorcy);
        }

        // POST: AOdbiorcies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AOdbiorcy aOdbiorcy = db.AOdbiorcies.Find(id);
            db.AOdbiorcies.Remove(aOdbiorcy);
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
