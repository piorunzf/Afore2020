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
    public class ZdjeciaKartiesController : Controller
    {
        private AforeContext db = new AforeContext();

        // GET: ZdjeciaKarties
        public ActionResult Index()
        {
            return View(db.ZdjeciaKarties.ToList());
        }

        // GET: ZdjeciaKarties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // ZdjeciaKarty zdjeciaKarty = db.ZdjeciaKarties.Find(id);
            // Student student = db.Students.Include(s => s.Files).SingleOrDefault(s => s.ID == id);
            ZdjeciaKarty zdjeciaKarty = db.ZdjeciaKarties.Include(s => s.ZdjeciaKartyZdjecie).SingleOrDefault(s => s.ZdjeciaKartyID == id);
            if (zdjeciaKarty == null)
            {
                return HttpNotFound();
            }
            return View(zdjeciaKarty);
        }

        // GET: ZdjeciaKarties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZdjeciaKarties/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZdjeciaKartyID,ZdjeciaKartyNazwa,ZdjeciaKartyOpis,ZdjeciaKartyZdjecie,ZdjeciaKartyDataTworzenia,ZdjeciaKartyOperatorTw,ZdjeciaKartyDatamodyfikacji,ZdjeciaKartyOperatorMd")] ZdjeciaKarty zdjeciaKarty, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new ZdjeciaKarty
                    {
                       // FileName = System.IO.Path.GetFileName(upload.FileName),
                        //FileType = FileType.Avatar,
                       // ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.ZdjeciaKartyZdjecie = reader.ReadBytes(upload.ContentLength);
                    }
                    zdjeciaKarty.ZdjeciaKartyZdjecie = avatar.ZdjeciaKartyZdjecie;

                    //student.Files = new List<File> { avatar };
                }

                db.ZdjeciaKarties.Add(zdjeciaKarty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zdjeciaKarty);
        }

        // GET: ZdjeciaKarties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZdjeciaKarty zdjeciaKarty = db.ZdjeciaKarties.Find(id);
            if (zdjeciaKarty == null)
            {
                return HttpNotFound();
            }
            return View(zdjeciaKarty);
        }

        // POST: ZdjeciaKarties/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZdjeciaKartyID,ZdjeciaKartyNazwa,ZdjeciaKartyOpis,ZdjeciaKartyZdjecie,ZdjeciaKartyDataTworzenia,ZdjeciaKartyOperatorTw,ZdjeciaKartyDatamodyfikacji,ZdjeciaKartyOperatorMd")] ZdjeciaKarty zdjeciaKarty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zdjeciaKarty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zdjeciaKarty);
        }

        // GET: ZdjeciaKarties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZdjeciaKarty zdjeciaKarty = db.ZdjeciaKarties.Find(id);
            if (zdjeciaKarty == null)
            {
                return HttpNotFound();
            }
            return View(zdjeciaKarty);
        }

        // POST: ZdjeciaKarties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZdjeciaKarty zdjeciaKarty = db.ZdjeciaKarties.Find(id);
            db.ZdjeciaKarties.Remove(zdjeciaKarty);
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
