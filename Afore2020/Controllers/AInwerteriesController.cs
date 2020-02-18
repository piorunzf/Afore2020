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
    public class AInwerteriesController : Controller
    {
        private AforeContext db = new AforeContext();

        // GET: AInwerteries
        public ActionResult Index()
        {
            return View(db.AInwerteries.ToList());
        }

        // GET: AInwerteries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AInwertery aInwertery = db.AInwerteries.Find(id);
            if (aInwertery == null)
            {
                return HttpNotFound();
            }
            return View(aInwertery);
        }

        // GET: AInwerteries/Create
        public ActionResult Create()
        {

            AInwertery aInwertery = new AInwertery();
            aInwertery.AInwerteryDatamodyfikacji = DateTime.Now;
            aInwertery.AInwerteryDataTworzenia = DateTime.Now;
            aInwertery.AInwerteryOperatorMd = "Admin";
            aInwertery.AInwerteryiOperatorTw = "Admin";

            return View(aInwertery);
        }

        // POST: AInwerteries/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AInwerteryID,AInwerteryModelInwentera,AInwerteryOpis,AInwerteryAktywny,AInwerteryDataTworzenia,AInwerteryiOperatorTw,AInwerteryDatamodyfikacji,AInwerteryOperatorMd")] AInwertery aInwertery)
        {
            if (ModelState.IsValid)
            {
                db.AInwerteries.Add(aInwertery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aInwertery);
        }

        // GET: AInwerteries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AInwertery aInwertery = db.AInwerteries.Find(id);
            if (aInwertery == null)
            {
                return HttpNotFound();
            }
            return View(aInwertery);
        }

        // POST: AInwerteries/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AInwerteryID,AInwerteryModelInwentera,AInwerteryOpis,AInwerteryAktywny,AInwerteryDataTworzenia,AInwerteryiOperatorTw,AInwerteryDatamodyfikacji,AInwerteryOperatorMd")] AInwertery aInwertery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aInwertery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aInwertery);
        }

        // GET: AInwerteries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AInwertery aInwertery = db.AInwerteries.Find(id);
            if (aInwertery == null)
            {
                return HttpNotFound();
            }
            return View(aInwertery);
        }

        // POST: AInwerteries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AInwertery aInwertery = db.AInwerteries.Find(id);
            db.AInwerteries.Remove(aInwertery);
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
