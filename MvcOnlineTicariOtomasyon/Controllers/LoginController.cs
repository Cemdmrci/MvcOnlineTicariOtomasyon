﻿using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous] //Beni Authorize dan muaf tut
    public class LoginController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
            {
                return View();
            }

            [HttpGet]
            public PartialViewResult Partial1()
            {
                return PartialView();
            }

            [HttpPost]
            public PartialViewResult Partial1(Cariler cari)
            {
                context.Carilers.Add(cari);
                context.SaveChanges();

                return PartialView();
            }

            [HttpGet]
            public ActionResult CariLogin()
            {
                return View();
            }

            [HttpPost]
            public ActionResult CariLogin(Cariler cari)
            {
                var bilgiler = context.Carilers.FirstOrDefault(x => x.CariMail == cari.CariMail && x.CariSifre == cari.CariSifre);

                if (bilgiler != null)
                {
                    FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                    Session["CariMail"] = bilgiler.CariMail.ToString();
                    return RedirectToAction("Index", "CariPanel");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            [HttpGet]
            public ActionResult AdminLogin()
            {
                return View();
            }

            [HttpPost]
            public ActionResult AdminLogin(Admin admin)
            {
                var bilgiler = context.Admins.FirstOrDefault(x => x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);

                if (bilgiler != null)
                {
                    FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                    Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                    return RedirectToAction("Index", "Kategori");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
    }
}