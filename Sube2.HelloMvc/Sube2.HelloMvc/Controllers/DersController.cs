using Microsoft.AspNetCore.Mvc;
using Sube2.HelloMvc.Models;
using System.Collections.Generic;

namespace Sube1.HelloMVC.Controllers
{
    public class DersController : Controller
    {
        public ViewResult Index() // Ana Sayfa Metodu
        {
            return View();
        }

        public ViewResult DersDetay(int id)
        {
            Ders ders = null;
            if (id == 1)
            {
                ders = new Ders { Dersid = 1, Dersad = "ProgTem", Kredi = 5 };
            }
            else if (id == 2)
            {
                ders = new Ders { Dersid = 2, Dersad = "Veri Yapıları", Kredi = 4 };
            }

            ViewData["ders"] = ders;
            ViewBag.course = ders;

            return View(ders);
        }

        public ViewResult DersListe()
        {
            var dersListesi = new List<Ders>
            {
                new Ders { Dersid = 1, Dersad = "ProgTem", Kredi = 5 },
                new Ders { Dersid = 2, Dersad = "Veri Yapıları", Kredi = 4 },
                new Ders { Dersid = 3, Dersad = "Algoritmalar", Kredi = 3 }
            };

            return View(dersListesi);
        }

        public ViewResult DersEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DersEkle(Ders yeniDers)
        {
            if (ModelState.IsValid)
            {
                // Yeni dersi ekle işlemi burada yapılır (veritabanına ekleme vb.)
                // Örneğin: dersListesi.Add(yeniDers);
                return RedirectToAction("DersListe");
            }
            return View(yeniDers);
        }

        public ViewResult DersGuncelle(int id)
        {
            // Güncellenecek dersi bulma işlemi burada yapılır
            Ders mevcutDers = new Ders { Dersid = id, Dersad = "Mevcut Ders", Kredi = 3 };

            return View(mevcutDers);
        }

        [HttpPost]
        public IActionResult DersGuncelle(Ders guncellenmisDers)
        {
            if (ModelState.IsValid)
            {
                // Güncelleme işlemi burada yapılır
                // Örneğin: mevcutDers.Dersad = guncellenmisDers.Dersad;
                return RedirectToAction("DersListe");
            }
            return View(guncellenmisDers);
        }

        public IActionResult DersSil(int id)
        {
            // Silme işlemi burada yapılır
            // Örneğin: dersListesi.Remove(dersListesi.First(d => d.Dersid == id));
            return RedirectToAction("DersListe");
        }
    }
}
