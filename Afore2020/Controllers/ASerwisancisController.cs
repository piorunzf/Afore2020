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
    public class ASerwisancisController : Controller
    {
        private AforeContext db = new AforeContext();

        // GET: ASerwisancis
        public ActionResult Index()
        {
            return View(db.ASerwisancis.ToList());
        }

        // GET: ASerwisancis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASerwisanci aSerwisanci = db.ASerwisancis.Find(id);
            if (aSerwisanci == null)
            {
                return HttpNotFound();
            }
            return View(aSerwisanci);
        }

        // GET: ASerwisancis/Create
        public ActionResult Create()

        {
            ASerwisanci aSerwisanci = new ASerwisanci();
            aSerwisanci.ASerwisanciOperatorTw = "Admin";
            aSerwisanci.ASerwisanciOperatorMd = "Admin";
            aSerwisanci.ASerwisanciDataTworzenia = DateTime.Now;
            aSerwisanci.ASerwisanciDatamodyfikacji = DateTime.Now;


            return View(aSerwisanci);
        }

        // POST: ASerwisancis/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ASerwisanciID,ASerwisanciImię,ASerwisanciNazwisko,ASerwisanciTelefon,ASerwisanciOpis,ASerwisanciAktywny,ASerwisanciDataTworzenia,ASerwisanciOperatorTw,ASerwisanciDatamodyfikacji,ASerwisanciOperatorMd")] ASerwisanci aSerwisanci)
        {
           

            if (ModelState.IsValid)
            {
                               
                db.ASerwisancis.Add(aSerwisanci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aSerwisanci);
        }

        // GET: ASerwisancis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASerwisanci aSerwisanci = db.ASerwisancis.Find(id);
            if (aSerwisanci == null)
            {
                return HttpNotFound();
            }
            return View(aSerwisanci);
        }

        // POST: ASerwisancis/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ASerwisanciID,ASerwisanciImię,ASerwisanciNazwisko,ASerwisanciTelefon,ASerwisanciOpis,ASerwisanciAktywny,ASerwisanciDataTworzenia,ASerwisanciOperatorTw,ASerwisanciDatamodyfikacji,ASerwisanciOperatorMd")] ASerwisanci aSerwisanci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aSerwisanci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aSerwisanci);
        }

        // GET: ASerwisancis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASerwisanci aSerwisanci = db.ASerwisancis.Find(id);
            if (aSerwisanci == null)
            {
                return HttpNotFound();
            }
            return View(aSerwisanci);
        }

        // POST: ASerwisancis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ASerwisanci aSerwisanci = db.ASerwisancis.Find(id);
            db.ASerwisancis.Remove(aSerwisanci);
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
