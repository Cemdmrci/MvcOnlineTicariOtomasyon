using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
		// GET: Personel
		Context context = new Context();

		public ActionResult Index()
		{
			var personeller = context.Personels.ToList();
			return View(personeller);
		}

		[HttpGet]
		public ActionResult PersonelEkle()
		{
			List<SelectListItem> departmanList = (from x in context.Departmans.ToList()
												  select new SelectListItem
												  {
													  Text = x.DepartmanAd,
													  Value = x.Departmanid.ToString()
												  }).ToList();
			ViewBag.DepartmanList = departmanList;

			return View();
		}

		[HttpPost]
		public ActionResult PersonelEkle(Personel personel)
		{
			if (Request.Files.Count > 0) //Yaptığım istekler arasında bir dosya mevcutsa
			{
				string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
				string uzanti = Path.GetExtension(Request.Files[0].FileName);
				string yol = "~/Image/" + dosyaadi + uzanti;
				Request.Files[0].SaveAs(Server.MapPath(yol));
				personel.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
			}
			context.Personels.Add(personel);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult PersonelGetir(int id)
		{
			List<SelectListItem> departmanList = (from x in context.Departmans.ToList()
												  select new SelectListItem
												  {
													  Text = x.DepartmanAd,
													  Value = x.Departmanid.ToString()
												  }).ToList();
			ViewBag.DepartmanList = departmanList;
			var personel = context.Personels.Find(id);
			return View("PersonelGetir", personel);
		}

		public ActionResult PersonelGuncelle(Personel personel)
		{
			if (Request.Files.Count > 0)
			{
				string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
				string uzanti = Path.GetExtension(Request.Files[0].FileName);
				string yol = "~/Image/" + dosyaadi + uzanti;
				Request.Files[0].SaveAs(Server.MapPath(yol));
				personel.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
			}
			var Personel = context.Personels.Find(personel.Personelid);
			Personel.PersonelAd = personel.PersonelAd;
			Personel.PersonelSoyad = personel.PersonelSoyad;
			Personel.PersonelGorsel = personel.PersonelGorsel;
			Personel.Departmanid = personel.Departmanid;
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult PersonelList()
		{
			var sorgu = context.Personels.ToList();
			return View(sorgu);
		}
    }
}