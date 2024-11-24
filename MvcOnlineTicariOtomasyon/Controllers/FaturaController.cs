using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var liste = context.Faturalars.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar fatura)
        {
            context.Faturalars.Add(fatura);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = context.Faturalars.Find(id);

            return View(fatura);
        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = context.Faturalars.Find(f.Faturaid);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSıraNo = f.FaturaSıraNo;
            fatura.Saat = f.Saat;
            fatura.Tarih = f.Tarih;
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.TeslimEden = f.TeslimEden;
            fatura.VergiDairesi = f.VergiDairesi;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var faturaKalems = context.FaturaKalems.Where(x => x.FaturaKalemid == id).ToList();

            return View(faturaKalems);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem faturaKalem)
        {
            context.FaturaKalems.Add(faturaKalem);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}