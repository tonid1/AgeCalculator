using AgeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AgeCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new DatumRodjenja());
        }

        [HttpPost]
        public ActionResult Index(DatumRodjenja datumRodj)
        {
            if (datumRodj.Datum > DateTime.Now)
            {
                ViewBag.Error = "Datum rodjenja ne moze biti veci od trenutnog datuma.";
            }
            else
            {
                ViewBag.Uvod = "Od Vaseg datuma rodjenja do danasnjeg dana proslo je: ";

                int godine = (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(datumRodj.Datum.Year.ToString())) * 12;
                int mjeseci = int.Parse(DateTime.Now.Month.ToString()) - int.Parse(datumRodj.Datum.Month.ToString());

                ViewBag.StarostMj = "U mjesecima: " + (godine + mjeseci) + " mjeseci,";

                TimeSpan starost = DateTime.Now - datumRodj.Datum;

                ViewBag.StarostDan = "U danima: " + Math.Round(starost.TotalDays) + " dana,";
                ViewBag.StarostSat = "U satima: " + Math.Round(starost.TotalHours) + " sati,";
                ViewBag.StarostMin = "U minutama: " + Math.Round(starost.TotalMinutes) + " minuta,";
                ViewBag.StarostSek = "U sekundama: " + Math.Round(starost.TotalSeconds) + " sekunda";
            }

            return View(datumRodj);
        }

        [HttpGet]
        public ActionResult DatePicker()
        {
            return View(new DatumRodjenja());
        }

        [HttpPost]
        public ActionResult DatePicker(DatumRodjenja datumRodj)
        {           
            if (datumRodj.Datum > DateTime.Now)
            {
                ViewBag.Error = "Datum rodjenja ne moze biti veci od trenutnog datuma.";
            }
            else
            {
                ViewBag.Uvod = "Od Vaseg datuma rodjenja do danasnjeg dana proslo je: ";

                int godine = (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(datumRodj.Datum.Year.ToString())) * 12;
                int mjeseci = int.Parse(DateTime.Now.Month.ToString()) - int.Parse(datumRodj.Datum.Month.ToString());

                ViewBag.StarostMj = "U mjesecima: " + (godine + mjeseci) + " mjeseci,";

                TimeSpan starost = DateTime.Now - datumRodj.Datum;

                ViewBag.StarostDan = "U danima: " + Math.Round(starost.TotalDays) + " dana,";
                ViewBag.StarostSat = "U satima: " + Math.Round(starost.TotalHours) + " sati,";
                ViewBag.StarostMin = "U minutama: " + Math.Round(starost.TotalMinutes) + " minuta,";
                ViewBag.StarostSek = "U sekundama: " + Math.Round(starost.TotalSeconds) + " sekunda";
            }

            return View(datumRodj);
        }        

        [HttpGet]
        public async Task<ActionResult> Ajax()
        {
            return View(new DatumRodjenja());
        }

        [HttpPost]
        public ActionResult Ajax(DatumRodjenja datumRodj)
        {
            return Json(datumRodj , JsonRequestBehavior.AllowGet);
        }
    }
}