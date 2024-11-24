using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using Context = MvcOnlineTicariOtomasyon.Models.Sınıflar.Context;

namespace MvcOnlineTicariOtomasyon.Controllers
{
	public class CariController : Controller
	{
		Context context = new Context();
		public ActionResult Index()
		{
			var degerler = context.Carilers.Where(x => x.Durum == true).ToList();
			return View(degerler);
		}

		[HttpGet]
		public ActionResult YeniCari()
		{
			return View();
		}

		[HttpPost]
		public ActionResult YeniCari(Cariler cari)
		{
			cari.Durum = true;
			context.Carilers.Add(cari);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult CariSil(int id)
		{
			var cari = context.Carilers.Find(id);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult CariGetir(int id)
		{
			var cari = context.Carilers.Find(id);
			return View("CariGetir", cari);
		}

		public ActionResult CariGuncelle(Cariler cari)
		{
			if (!ModelState.IsValid) /*Modelstatenin geçerlemesi doğru değilse*/
			{
				return View("CariGetir");
			}
			var Cari = context.Carilers.Find(cari.Cariid);
			Cari.CariAd = cari.CariAd;
			Cari.CariSoyad = cari.CariSoyad;
			Cari.CariSehir = cari.CariSehir;
			Cari.CariMail = cari.CariMail;
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult MusteriSatis(int id)
		{
			var values = context.SatisHarekets.Where(x => x.Cariid == id).ToList();
			var cari = context.Carilers.Where(x => x.Cariid == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
			ViewBag.Cari = cari;

			return View(values);
		}
	}
}