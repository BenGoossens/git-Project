using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using MySql.Data.MySqlClient;
using Project_Krekelhof.Models.DAL;
using Project_Krekelhof.Models.Domain;
using Project_Krekelhof.ViewModels;

namespace Project_Krekelhof.Controllers
{
    public class LeerlingController : Controller
    {
        private ILeerlingRepository leerlingRepository;
        //private IUitleningRepository UitleningRepository;

        private Medewerker medewerker;
        private Gebruiker gebruiker;

        public LeerlingController(ILeerlingRepository leerlingRepository)
        {
            gebruiker = new Gebruiker(null, null, null, null, null, leerlingRepository, null);
            medewerker = new Medewerker(null, null, null, null, null, leerlingRepository, null);
            this.leerlingRepository = leerlingRepository;
        }

        // GET: Leerling
        public ActionResult Index(String zoekstring = null)
        {
            IEnumerable<Leerling> leerlingen;
            if (!String.IsNullOrEmpty(zoekstring))
            {
                leerlingen = gebruiker.GeefLeerlingen(zoekstring);
                ViewBag.Selection = "Alle leerlingen met '" + zoekstring + "'";
            }
            else
            {
                leerlingen = gebruiker.GeefLeerlingen(zoekstring);
                ViewBag.Selection = "Alle leerlingen";
            }
            if (Request.IsAjaxRequest())
                return PartialView("Lijst", new LeerlingIndexViewModel(leerlingen));

            return View(new LeerlingIndexViewModel(leerlingen));
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            DataSet ds = new DataSet();
            if (Request.Files["file"].ContentLength > 0)
            {
                string fileExtension =
                    System.IO.Path.GetExtension(Request.Files["file"].FileName);

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {

                        System.IO.File.Delete(fileLocation);
                    }
                    Request.Files["file"].SaveAs(fileLocation);
                    string excelConnectionString = string.Empty;
                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                    fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    //connection String for xls file format.
                    if (fileExtension == ".xls")
                    {
                        excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    //connection String for xlsx file format.
                    else if (fileExtension == ".xlsx")
                    {
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    //Create Connection to Excel work book and add oledb namespace
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    excelConnection.Open();
                    DataTable dt = new DataTable();

                    dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        return null;
                    }

                    String[] excelSheets = new String[dt.Rows.Count];
                    int t = 0;
                    //excel data saves in temp file here.
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[t] = row["TABLE_NAME"].ToString();
                        t++;
                    }
                    OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);

                    string query = string.Format("Select * from [{0}]", excelSheets[0]);
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                    {
                        dataAdapter.Fill(ds);
                    }
                }
                if (fileExtension.ToString().ToLower().Equals(".xml"))
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                        System.IO.File.Delete(fileLocation);
                    }

                    Request.Files["FileUpload"].SaveAs(fileLocation);
                    XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                    // DataSet ds = new DataSet();
                    ds.ReadXml(xmlreader);
                    xmlreader.Close();
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string connection = ConfigurationManager.ConnectionStrings["Krekelschool"].ConnectionString;
                    MySqlConnection connect = new MySqlConnection(connection);
                    string query =
                        "INSERT INTO Leerlingen(Voornaam,Familienaam,Straat,HuisNummer,Email,Klas) " +
                        "Values(@VOORNAAM, @FAMILIENAAM, @STRAAT, @HUISNUMMER, @EMAIL, @KLAS)";

                    connect.Open();
                    MySqlCommand command = new MySqlCommand(query, connect);
                    command.Parameters.AddWithValue("@VOORNAAM", ds.Tables[0].Rows[i][0].ToString());
                    command.Parameters.AddWithValue("@FAMILIENAAM", ds.Tables[0].Rows[i][1].ToString());
                    command.Parameters.AddWithValue("@STRAAT", ds.Tables[0].Rows[i][2].ToString());
                    command.Parameters.AddWithValue("@HUISNUMMER", ds.Tables[0].Rows[i][3].ToString());
                    command.Parameters.AddWithValue("@EMAIL", ds.Tables[0].Rows[i][4].ToString());
                    command.Parameters.AddWithValue("@KLAS", ds.Tables[0].Rows[i][5].ToString());
                    command.ExecuteNonQuery();
                    connect.Close();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            Leerling leerling = new Leerling();
            ViewBag.Title = "Leerling toevoegen";
            return View(new LeerlingViewModel(leerling));
        }

        [HttpPost]
        public ActionResult Create(LeerlingViewModel lvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Leerling leerling = new Leerling();
                    MapToLeerling(lvm, leerling);
                    leerlingRepository.Add(leerling);
                    leerlingRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", leerling.Voornaam);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(lvm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Leerling leerling = leerlingRepository.FindById(id);
            if (leerling == null)
                return HttpNotFound();
            return View("Create", new LeerlingViewModel(leerling));
        }

        [HttpPost]
        public ActionResult Edit(int id, LeerlingViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Leerling leerling = leerlingRepository.FindById(id);
                    MapToLeerling(lvm, leerling);
                    leerlingRepository .SaveChanges();
                    TempData["message"] = String.Format("Leerling {0} werd aangepast", leerling.Voornaam);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View("Create", lvm);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Leerling leerling = leerlingRepository.FindById(id);
            if (leerling == null)
                return HttpNotFound();
            return View(new LeerlingViewModel(leerling));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Leerling leerling = leerlingRepository.FindById(id);
                if (leerling == null)
                    return HttpNotFound();
                leerlingRepository.Delete(leerling);
                leerlingRepository.SaveChanges();
                TempData["message"] = String.Format("Leerling {0} werd verwijderd", leerling.Voornaam);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Verwijderen Leerling mislukt. Probeer opnieuw. ";
            }
            return RedirectToAction("Index");
        }

        private void MapToLeerling(LeerlingViewModel lvm, Leerling leerling)
        {
            //leerling.Id = lvm.Id;
            leerling.Voornaam = lvm.Voornaam;
            leerling.Familienaam = lvm.Familienaam;
            leerling.Straat = lvm.Straat;
            leerling.Huisnummer = lvm.Huisnummer;
            leerling.Email = lvm.Email;
            leerling.Klas = lvm.Klas;
        }
    }
}