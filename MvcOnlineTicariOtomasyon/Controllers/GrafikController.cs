using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 98 }).Write();

            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index3()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var sonuclar = context.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xValue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yValue.Add(y.Stok));

            var grafik = new Chart(width: 800, height: 800)
                .AddTitle("Kategori - Ürün Stok Sayısı")
                .AddLegend("Stok")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xValue, yValues: yValue);

            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }
        //Google chartlarda görselleştirmeye ulaşabailmek için
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }

        public List<Sinif1> UrunListesi()
        {
            List<Sinif1> snf = new List<Sinif1>();

            snf.Add(new Sinif1()
            {
                UrunAd = "Bilgisayar",
                Stok = 120
            });

            snf.Add(new Sinif1()
            {
                UrunAd = "Beyaz Eşya",
                Stok = 150
            });

            snf.Add(new Sinif1()
            {
                UrunAd = "Mobilya",
                Stok = 70
            });

            snf.Add(new Sinif1()
            {
                UrunAd = "Küçük Ev Aletleri",
                Stok = 180
            });

            snf.Add(new Sinif1()
            {
                UrunAd = "Mobil Cihazlar",
                Stok = 90
            });

            return snf;
        }

        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<Sinif2> UrunListesi2()
        {
            List<Sinif2> snf = new List<Sinif2>();

            using (var context = new Context())
            {
                snf = context.Uruns.Select(x => new Sinif2
                {
                    UrunAd = x.UrunAd,
                    Stok = x.Stok
                }).ToList();
            }

            return snf;
        }

        public ActionResult Index6()
        {
            return View();
        }

        public ActionResult Index7()
        {
            return View();
        }
    }
}