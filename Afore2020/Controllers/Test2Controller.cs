using Afore2020.DAL;
using Afore2020.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Afore2020.Controllers
{
    public class Test2Controller : Controller
    {
        // GET: Test2
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.ImportExcel importExcel)
        {
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Content/Upload/" + importExcel.file.FileName);
                importExcel.file.SaveAs(path);

                string excelConnectionString = @"Provider='Microsoft.ACE.OLEDB.12.0';Data Source='" + path + "';Extended Properties='Excel 12.0 Xml;IMEX=1'";

                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

                //Sheet Name
                excelConnection.Open();
                string tableName = excelConnection.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();
                excelConnection.Close();
                //End

                DataTable dataTable = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from [" + tableName + "]", excelConnection);
                adapter.Fill(dataTable);

                Session["ExcelData"] = dataTable;
                //ReadSession(1);


                excelConnection.Open();


                int ilosc = dataTable.Rows.Count;

                 AforeContext db = new AforeContext();
                AOdbiorcy aOdbiorcy = new AOdbiorcy();

                var record = dataTable.AsEnumerable().Select(p => p).ToArray();

                var rec = dataTable.Rows[1];

                aOdbiorcy.AOdbiorcyKod = rec.ItemArray[0].ToString();
                aOdbiorcy.AOdbiorcyNazwa = rec.ItemArray[1].ToString();
                aOdbiorcy.AOdbiorcyNIP = rec.ItemArray[2].ToString();
                aOdbiorcy.AOdbiorcyKodPocztowy = rec.ItemArray[3].ToString();
                aOdbiorcy.AOdbiorcyPoczta = "";
                aOdbiorcy.AMiastaID = 1;
                aOdbiorcy.AWojewodztwoID = 1;
                aOdbiorcy.AOdbiorcyTelefon = "";
                aOdbiorcy.AOdborcaUwagi = "";
                aOdbiorcy.AOdbiorcyUlicaNumerDomuLokalu = "";

                aOdbiorcy.AOdbiorcaEmail = "brak@brak.pl";

                db.AOdbiorcies.Add(aOdbiorcy);
                db.SaveChanges();
                






                ViewBag.Result = "Successfully Imported" + ilosc.ToString() + dataTable.Rows[0].ItemArray[1].ToString();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Reset()
        {
            Session["ExcelData"] = null;
            return RedirectToAction("Index");
        }
    }
}