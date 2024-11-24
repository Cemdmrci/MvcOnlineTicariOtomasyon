using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context context = new Context();

        public ActionResult Index()
        {
            var satislar = context.SatisHarekets.ToList();
            return View(satislar);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> urunList = (from x in context.Uruns.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.UrunAd,
                                                 Value = x.Urunid.ToString()
                                             }).ToList();
            ViewBag.UrunList = urunList;

            List<SelectListItem> cariList = (from x in context.Carilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CariAd + " " + x.CariSoyad,
                                                 Value = x.Cariid.ToString()
                                             }).ToList();
            ViewBag.CariList = cariList;

            List<SelectListItem> personelList = (from x in context.Personels.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                     Value = x.Personelid.ToString()
                                                 }).ToList();
            ViewBag.PersonelList = personelList;

            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satisHareket)
        {
            satisHareket.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> urunList = (from x in context.Uruns.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.UrunAd,
                                                 Value = x.Urunid.ToString()
                                             }).ToList();
            ViewBag.UrunList = urunList;

            List<SelectListItem> cariList = (from x in context.Carilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CariAd + " " + x.CariSoyad,
                                                 Value = x.Cariid.ToString()
                                             }).ToList();
            ViewBag.CariList = cariList;

            List<SelectListItem> personelList = (from x in context.Personels.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                     Value = x.Personelid.ToString()
                                                 }).ToList();
            ViewBag.PersonelList = personelList;

            var satis = context.SatisHarekets.Find(id);
            return View("SatisGetir", satis);
        }

        public ActionResult SatisGuncelle(SatisHareket satisHareket)
        {
            var Satis = context.SatisHarekets.Find(satisHareket.Satisid);
            Satis.Cariid = satisHareket.Cariid;
            Satis.Adet = satisHareket.Adet;
            Satis.Fiyat = satisHareket.Fiyat;
            Satis.Personelid = satisHareket.Personelid;
            Satis.Tarih = DateTime.Now;
            Satis.ToplamTutar = satisHareket.ToplamTutar;
            Satis.Urunid = satisHareket.Urunid;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var values = context.SatisHarekets.Where(x => x.Satisid == id).ToList();
            return View(values);
        }

        public ActionResult UrunListesi()
        {
            var values = context.Uruns.ToList();
            return View(values);
        }
    }
}