using Afore2020.DAL;
using Afore2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Afore2020.Controllers
{
    public class HomeController : Controller
    {
        private AforeContext db = new AforeContext();
        private OgniwoContext dbOgniwo = new OgniwoContext();

             
        public ActionResult Index()
        {
            ViewBag.Message = "+++++++++++++++++++++++++++";
            return View();
        }

        public ActionResult About()
        {
            //to dziala
            AuxiliaryFunction kopiowanie = new AuxiliaryFunction();
            // kopiowanie.CopyWojewodztwa();
            kopiowanie.CopyMiasto();
            














            ViewBag.Message = "-------------------------.";

            return View(dbOgniwo.owojewodztwos.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}