using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UygulamaWebSıte.Models;
using UygulamaWebSıte.Business;
namespace UygulamaWebSıte.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Kategori Kategori)
        {
            var Insert = new List<string>();
            NWBusinessLogic nwBusiness = new NWBusinessLogic();
            nwBusiness.SaveCustomer(Kategori);
            ViewBag.Insert = new SelectList(Insert);
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            Insert();
           // ViewBag.Kategoriler = kategoriAdi;
            return View();
        }



        
    }
}