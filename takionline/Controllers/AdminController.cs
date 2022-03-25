using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using takionline.DTO;
using takionline.Models;


namespace takionline.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Kullanici()
        {
            if (Session["Kullanici"] == null)
            {
                GirisKontrol model = new GirisKontrol(); 
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            takısatışıEntities _db = new takısatışıEntities();
            var kullanicilar = _db.Kullanici.ToList();
            return View(kullanicilar);
        }
        public ActionResult Müsteri()
        {
            if (Session["Kullanici"] ==null)
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            takısatışıEntities _db = new takısatışıEntities();
            var müsteriler = _db.Müsteri.ToList();
            return View(müsteriler);
        }
        public ActionResult Gelirgider()
        {
            return View();
        }
        public ActionResult Giris()
        {
            return View();
        }
        public ActionResult Yönetici()
        {
            if (Session["Kullanici"] == null)
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            return View();
        }

        public ActionResult Üyeler()
        {
            if (Session["Kullanici"] == null)
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            takısatışıEntities _db = new takısatışıEntities();
            var üyeler = _db.Firma.ToList();
            return View(üyeler);
           
        }
        public ActionResult ÜyeKayit(int? Id)
        {
            if (Session["Kullanici"] == null)
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            takısatışıEntities _db = new takısatışıEntities();
            if (Id != null)
            {
                var entity = _db.Firma.Find(Id);
                return View(entity);
            }
            else
                return View();
        }



        public ActionResult KullaniciKayit(int? Id)
        {
            if (Session["Kullanici"] == null)
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            takısatışıEntities _db = new takısatışıEntities();
            if (Id != null)
            {
                var entity = _db.Kullanici.Find(Id);
                return View(entity);
            }
            else
                return View();
        }
        public ActionResult KullaniciEkle(Kullanici entity)
        {
            if (Session["Kullanici"] == null)
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            takısatışıEntities _db = new takısatışıEntities();
            if (entity.Id > 0)
            {
                var kayit = _db.Kullanici.Find(entity.Id);
                kayit.Adi = entity.Adi;
                kayit.Email = entity.Email;
                kayit.KullaniciAdi = entity.KullaniciAdi;
                kayit.Sifre = entity.Sifre;
                kayit.Tel = entity.Tel;
                kayit.Soyadi = entity.Soyadi;
                _db.Kullanici.Add(entity);
                _db.SaveChanges();
                _db.SaveChanges();
                var kullanıcılar = _db.Kullanici.ToList();
                return View("/Views/Admin/Kullanici.cshtml", kullanıcılar);
            }
            else
            {
                return View("/Views/Admin/Kullanici.cshtml");

            }

           
           
            //return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MüsteriEkle(Müsteri entity)
        {
            if (Session["Kullanici"] == null)
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            takısatışıEntities _db = new takısatışıEntities();
            if (entity.Id > 0)

            {
                var kayit = _db.Müsteri.Find(entity.Id);
                kayit.MüsteriAdi = entity.MüsteriAdi;
                kayit.Email = entity.Email;
                kayit.TCKimlikNo = entity.TCKimlikNo;
                kayit.Adres = entity.Adres;
                kayit.Tel = entity.Tel;
                kayit.MüsteriSoyadi = entity.MüsteriSoyadi;
                entity.EklemeTarihi = entity.EklemeTarihi;
                _db.Müsteri.Add(entity);
                _db.SaveChanges();
                _db.SaveChanges();
                var müsteriler = _db.Müsteri.ToList();
                return View("/Views/Admin/Müsteri.cshtml", müsteriler);
            }

            
            else
            {

                return View("/Views/Admin/Müsteri.cshtml");
            }

        }

            //return Json(true, JsonRequestBehavior.AllowGet);

        
        public ActionResult ÜyeEkle(Firma entity)
        {
            if (Session["Kullanici"] == null)
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            takısatışıEntities _db = new takısatışıEntities();
            if (entity.Id > 0)
            {
                var kayit = _db.Firma.Find(entity.Id);
                kayit.FirmaAdi = entity.FirmaAdi;
                kayit.FirmaMail = entity.FirmaMail;
                kayit.Stok = entity.Stok;
                kayit.FirmaTel = entity.FirmaTel;
                _db.Firma.Add(entity);
                _db.SaveChanges();
                _db.SaveChanges();
                var üyeler = _db.Firma.ToList();
                return View("/Views/Admin/Üyeler.cshtml", üyeler);
            }
            else
            {
                return View("/Views/Admin/Üyeler.cshtml");


            }



            //return Json(true, JsonRequestBehavior.AllowGet);
        }


        public ActionResult KullaniciSil(int Id)
        {
            if (Session["Kullanici"] == null)
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            takısatışıEntities _db = new takısatışıEntities();
            var entity = _db.Kullanici.Find(Id);
            _db.Kullanici.Remove(entity);
            _db.SaveChanges();
            var kullanicilar = _db.Kullanici.ToList();
            return View("/Views/Admin/Kullanici.cshtml", kullanicilar);

        }
        public ActionResult MüsteriSil(int Id)
        {
            if (Session["Kullanici"] == null)
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            takısatışıEntities _db = new takısatışıEntities();
            var entity = _db.Müsteri.Find(Id);
            _db.Müsteri.Remove(entity);
            _db.SaveChanges();
            var müsteriler = _db.Müsteri.ToList();
            return View("/Views/Admin/Müsteri.cshtml", müsteriler);

        }

        public ActionResult MüsteriKayit(int? Id)
        {
            if (Session["Kullanici"] == null)
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            takısatışıEntities _db = new takısatışıEntities();
            if (Id != null)
            {
                var entity = _db.Müsteri.Find(Id);
                return View(entity);
            }
            else
                return View();
        }
        public ActionResult GirisKontrol(string KullaniciAdi, string Sifre)
        {
            takısatışıEntities _db = new takısatışıEntities();

            var kullanici = _db.Kullanici.Where(w => w.KullaniciAdi == KullaniciAdi && w.Sifre == Sifre).FirstOrDefault();
            if (kullanici !=null)
            {
                Session["Kullanici"] = kullanici;
                _db.KullaniciGirisleri.Add(new KullaniciGirisleri
                {
                    KullaniciId = kullanici.Id,
                    EklemeTarihi = System.DateTime.Now
                });

                _db.SaveChanges();

                return View("/Views/Admin/Yönetici.cshtml");
            }
          
            else
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Kullanıcı adı veya şifre hatalı.";
                return View("/Views/Admin/Giris.cshtml", model);
            }
               

        }
        public ActionResult CikisYap()
        {
            Session["Kullanici"] = null;
            return View("/Views/Home/Index.cshtml");
        }

        public ActionResult Profil()
        {
            if (Session["Kullanici"] == null)
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            var kullanici = (Kullanici)Session["Kullanici"];
            return View(kullanici);
        }
        public ActionResult ProfilKaydet(Kullanici entity)
        {
            if (Session["Kullanici"] == null)
            {
                GirisKontrol model = new GirisKontrol();
                model.Mesaj = "Önce Giriş Yapmalısınız";
                return View("/Views/Admin/Giris.cshtml", model);
            }
            takısatışıEntities _db = new takısatışıEntities();
            if (entity.Id > 0)
            {
                var kayit = _db.Kullanici.Find(entity.Id);
                kayit.Adi = entity.Adi;
                kayit.Email = entity.Email;
                kayit.Sifre = entity.Sifre;
                kayit.Tel = entity.Tel;
                kayit.Soyadi = entity.Soyadi;

                _db.SaveChanges();
                Session["Kullanici"] = kayit;
            }
            return View("/Views/Admin/Yönetici.cshtml");

        }

        public ActionResult KullaniciGirisSayisi()
        {
            takısatışıEntities _db = new takısatışıEntities();
            var kullanicigirisleri = (from g in _db.KullaniciGirisleri
                                      join k in _db.Kullanici on g.KullaniciId equals k.Id
                                      select new
                                      {
                                          KullaniciAdi = k.Adi + " " + k.Soyadi,
                                          Tarih = g.EklemeTarihi,
                                          Id = g.Id

                                      }).ToList();

            List<KullaniciGirisSayisi> liste = new List<KullaniciGirisSayisi>();
            var grp = kullanicigirisleri.GroupBy(g => g.KullaniciAdi).Select(s => new KullaniciGirisSayisi { country = s.Key, litres = s.Count() }).ToList();

            liste.Add(new KullaniciGirisSayisi {
                country = "Dummy",
                disabled = true,
                litres = 1000,
                color = "#dadada",
                opacity=0.3,
                strokeDasharray= "4,4"
            });

            liste.AddRange(grp);

            return Json(liste, JsonRequestBehavior.AllowGet);
        }

    }
    public class KullaniciGirisSayisi
    {
        public string country { get; set; }
        public bool disabled { get; set; }
        public int litres { get; set; }
        public double opacity { get; set; }
        public string strokeDasharray { get; set; }
        public string color { get; set; }

    }
        

}