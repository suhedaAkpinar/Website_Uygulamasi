using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using UygulamaWebSıte.Mail;
using UygulamaWebSıte.VeriTransferNesneleri;
using System.IO;
using UygulamaWebSıte.Models;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using PagedList;
namespace UygulamaWebSıte.Controllers
{
    public class HomeController : Controller

    {
        private URUNLEREntities1 db = new URUNLEREntities1();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

       //URUNLEREntities1 _db = new URUNLEREntities1();
       // public ActionResult About(int? page)
       // {
       //     var res = _db.Kategori.ToList().ToPagedList(page ?? 1, 2);

       //     return View(res);
       // }

        [HttpPost]
        public ActionResult About(HttpPostedFileBase uploadfile)
        {
       
            if (uploadfile.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/Images/KullaniciResimleri"), Guid.NewGuid().ToString() + "_" + Path.GetFileName(uploadfile.FileName));
                uploadfile.SaveAs(filePath);
            }
            return View();
      
 
        }
        

        
    

//public ActionResult aAAAA()
//        {
//            List<kategori_getir_Result> kategoriList = db.kategori_getir().ToList();
          
//            return View();
//        }

        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Contact(Form form)
        {

            SendMail send = new SendMail();
            send.bana_Mail_At(form);
            send.ona_Mail_At(form);
            return View();
        }

        public ActionResult Yeni()
        {
            Urun urun = new Urun();
            Marka marka = new Marka();
            Kategoriler kategori = new Kategoriler();
            List<kategori_getir_Result> kategoriList = db.kategori_getir().ToList();

            var tupleData = new Tuple<Urun, Kategoriler, Marka, List<kategori_getir_Result>>(urun, kategori, marka, kategoriList);
            return View(tupleData);


        }
        //public ActionResult IndexAction(int a)
        //{

        //    return RedirectToAction("Yeni");

        //}
        [HttpPost]
        public ActionResult Yeni([Bind(Prefix = "Item1")]Urun Model1, [Bind(Prefix = "Item2")]Kategoriler Model2, [Bind(Prefix = "Item3")]Marka Model3)
        {
            if (Model1 != null)
            {
                if (Request.Files.Count > 0)
                {
                    string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                    string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    string TamYolYeri = "~/Images/KullaniciResimleri/" + DosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
                    Model1.Resim = DosyaAdi + uzanti;
                }
            }

            else if (Model2 != null)
            {
                db.KategoriProcedure(Model2.KategoriAdi);
            }

            else if (Model3 != null)
            {


           //     db.MarkaProcedure(Model3.MarkaAdi);
            }

            return View();
        }

        public ActionResult Kategori()
        {
           return View();
       }
     //  [HttpPost]
    //    public ActionResult Kategori(int? page)
      //  {
        //    int suankiSayfaIndexi = page.HasValue ? page.Value : 1;
         //   db.Kategori.OrderByDescending(Kategori => Kategori.kategoriId).ToPagedList(suankiSayfaIndexi, 1);
            

         //   return View();
        //}

        //public ActionResult Marka()
        //{

        //        return View();

        //}
        //[HttpPost]

        //public ActionResult Marka(int KategoriId)
        //      {


        //          {
        //         List<Marka> Marka = db.Marka.Where(x => x.kategoriId == KategoriId).ToList();


        //       return Json(Marka);
        //       }
        //      }

        
    }
    

}



