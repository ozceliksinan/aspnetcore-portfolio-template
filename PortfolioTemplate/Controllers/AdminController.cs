using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioTemplate.Data;
using PortfolioTemplate.Models;
using PortfolioTemplate.Repositories;

namespace PortfolioTemplate.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // DbConnection
        private readonly PortfolioDbContext _context;
        // SweetAlert
        private readonly AlertHelper _alertHelper;
        // Repository //
        private readonly DeneyimRepository deneyimRepository;
        private readonly HakkimdaRepository hakkimdaRepository;
        private readonly EgitimRepository egitimRepository;
        private readonly YetenekRepository yetenekRepository;
        private readonly SertifikaRepository sertifikaRepository;
        private readonly IletisimRepository iletisimRepository;
        private readonly HobiRepository hobiRepository;
        private readonly SosyalMedyaRepository sosyalMedyaRepository;

        public AdminController(PortfolioDbContext context)
        {
            // DbConnection
            _context = context;
            // SweetAlert
            _alertHelper = new AlertHelper(this);
            // Repository //
            deneyimRepository = new DeneyimRepository(_context);
            hakkimdaRepository = new HakkimdaRepository(_context);
            egitimRepository = new EgitimRepository(_context);
            yetenekRepository = new YetenekRepository(_context);
            sertifikaRepository = new SertifikaRepository(_context);
            iletisimRepository = new IletisimRepository(_context);
            hobiRepository = new HobiRepository(_context);
            sosyalMedyaRepository = new SosyalMedyaRepository(_context);
        }

        public IActionResult Index()
        {
            return View();
        }

        /* --- DENEYİM CRUD İŞLEMLERİ --- */
        public IActionResult Deneyim()
        {
            var degerler = deneyimRepository.List();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeneyimEkle(Deneyimler deneyimler)
        {
            deneyimRepository.Add(deneyimler);
            _alertHelper.SweetAlertShow("Deneyim", "Eklendi");
            return RedirectToAction("Deneyim", "Admin");
        }
        public IActionResult DeneyimSil(int id)
        {
            Deneyimler deneyimler = deneyimRepository.Get(id);
            deneyimRepository.Delete(deneyimler);
            _alertHelper.SweetAlertShow("Deneyim", "Silindi");
            return RedirectToAction("Deneyim", "Admin");
        }
        [HttpGet]
        public IActionResult DeneyimGuncelle(int id)
        {
            Deneyimler deneyimler = deneyimRepository.Get(id);
            return View(deneyimler);
        }
        [HttpPost]
        public IActionResult DeneyimGuncelle(Deneyimler deneyimler)
        {
            Deneyimler temp = deneyimRepository.Get(deneyimler.DeneyimlerId);
            temp.Baslik = deneyimler.Baslik;
            temp.AltBaslik = deneyimler.AltBaslik;
            temp.Aciklama = deneyimler.Aciklama;
            temp.Tarih = deneyimler.Tarih;
            deneyimRepository.Update(temp);
            _alertHelper.SweetAlertShow("Deneyim", "Guncellendi");
            return RedirectToAction("Deneyim", "Admin");
        }
        /* --- DENEYİM CRUD İŞLEMLERİ --- */

        /***********************************/

        /* --- HAKKIMDA CRUD İŞLEMLERİ --- */
        public IActionResult Hakkimda()
        {
            var degerler = sosyalMedyaRepository.ListWithRelations();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult SosyalMedyaEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SosyalMedyaEkle(SosyalMedya sosyalMedya)
        {
            sosyalMedyaRepository.Add(sosyalMedya);
            // Foreign Key Update
            SosyalMedya temp = sosyalMedyaRepository.Get(sosyalMedya.SosyalMedyaId);
            temp.HakkimdaId = 1;
            sosyalMedyaRepository.Update(temp);
            // Delete Extra About Value
            Hakkimda hakkimda = hakkimdaRepository.Get(sosyalMedya.SosyalMedyaId);
            hakkimdaRepository.Delete(hakkimda);
            _alertHelper.SweetAlertShow("Sosyal Medya", "Eklendi");
            return RedirectToAction("Hakkimda", "Admin");
        }
        public IActionResult SosyalMedyaSil(int id)
        {
            SosyalMedya sosyalMedya = sosyalMedyaRepository.Get(id);
            sosyalMedyaRepository.Delete(sosyalMedya);
            _alertHelper.SweetAlertShow("Sosyal Medya", "Silindi");
            return RedirectToAction("Hakkimda", "Admin");
        }
        [HttpGet]
        public IActionResult SosyalMedyaGuncelle(int id)
        {
            SosyalMedya sosyalMedya = sosyalMedyaRepository.Get(id);
            return View(sosyalMedya);
        }
        [HttpPost]
        public IActionResult SosyalMedyaGuncelle(SosyalMedya sosyalMedya)
        {
            SosyalMedya temp = sosyalMedyaRepository.Get(sosyalMedya.SosyalMedyaId);
            temp.Ad = sosyalMedya.Ad;
            temp.Link = sosyalMedya.Link;
            temp.Icon = sosyalMedya.Icon;
            sosyalMedyaRepository.Update(temp);
            _alertHelper.SweetAlertShow("Sosyal Medya", "Guncellendi");
            return RedirectToAction("Hakkimda", "Admin");
        }
        [HttpGet]
        public IActionResult HakkimdaGuncelle(int id)
        {
            Hakkimda hakkimda = hakkimdaRepository.Get(id);
            return View(hakkimda);
        }
        [HttpPost]
        public IActionResult HakkimdaGuncelle(Hakkimda hakkimda)
        {
            Hakkimda temp = hakkimdaRepository.Get(hakkimda.HakkimdaId);
            temp.Ad = hakkimda.Ad;
            temp.Soyad = hakkimda.Soyad;
            temp.Adres = hakkimda.Adres;
            temp.Telefon = hakkimda.Telefon;
            temp.Mail = hakkimda.Mail;
            temp.Aciklama = hakkimda.Aciklama;
            temp.Resim = hakkimda.Resim;

            hakkimdaRepository.Update(temp);
            _alertHelper.SweetAlertShow("Hakkimda", "Guncellendi");
            return RedirectToAction("Hakkimda", "Admin");
        }
        /* --- HAKKIMDA CRUD İŞLEMLERİ --- */

        /***********************************/

        /* --- EĞİTİMLER CRUD İŞLEMLERİ --- */
        public IActionResult Egitim()
        {
            var degerler = egitimRepository.List();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EgitimEkle(Egitim egitim)
        {
            egitimRepository.Add(egitim);
            _alertHelper.SweetAlertShow("Egitim", "Eklendi");
            return RedirectToAction("Egitim", "Admin");
        }
        public IActionResult EgitimSil(int id)
        {
            Egitim egitim = egitimRepository.Get(id);
            egitimRepository.Delete(egitim);
            _alertHelper.SweetAlertShow("Egitim", "Silindi");
            return RedirectToAction("Egitim", "Admin");
        }
        [HttpGet]
        public IActionResult EgitimGuncelle(int id)
        {
            Egitim egitim = egitimRepository.Get(id);
            return View(egitim);
        }
        [HttpPost]
        public IActionResult EgitimGuncelle(Egitim egitim)
        {
            Egitim temp = egitimRepository.Get(egitim.EgitimId);
            temp.Baslik = egitim.Baslik;
            temp.AltBaslik1 = egitim.AltBaslik1;
            temp.AltBaslik2 = egitim.AltBaslik2;
            temp.GNO = egitim.GNO;
            temp.Tarih = egitim.Tarih;
            egitimRepository.Update(temp);
            _alertHelper.SweetAlertShow("Egitim", "Guncellendi");
            return RedirectToAction("Egitim", "Admin");
        }
        /* --- EĞİTİMLER CRUD İŞLEMLERİ --- */

        /***********************************/

        /* --- YETENEKLER CRUD İŞLEMLERİ --- */
        public IActionResult Yetenek()
        {
            var degerler = yetenekRepository.List();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YetenekEkle(Yeteneklerim yeteneklerim)
        {
            yetenekRepository.Add(yeteneklerim);
            _alertHelper.SweetAlertShow("Yetenek", "Eklendi");
            return RedirectToAction("Yetenek", "Admin");
        }
        public IActionResult YetenekSil(int id)
        {
            Yeteneklerim yetenek = yetenekRepository.Get(id);
            yetenekRepository.Delete(yetenek);
            _alertHelper.SweetAlertShow("Yetenek", "Silindi");
            return RedirectToAction("Yetenek", "Admin");
        }
        [HttpGet]
        public IActionResult YetenekGuncelle(int id)
        {
            Yeteneklerim yeteneklerim = yetenekRepository.Get(id);
            return View(yeteneklerim);
        }
        [HttpPost]
        public IActionResult YetenekGuncelle(Yeteneklerim yeteneklerim)
        {
            Yeteneklerim temp = yetenekRepository.Get(yeteneklerim.YeteneklerimId);
            temp.Yetenek = yeteneklerim.Yetenek;
            temp.Oran = yeteneklerim.Oran;
            yetenekRepository.Update(temp);
            _alertHelper.SweetAlertShow("Yetenek", "Guncellendi");
            return RedirectToAction("Yetenek", "Admin");
        }
        /* --- YETENEKLER CRUD İŞLEMLERİ --- */

        /***********************************/

        /* --- SERTİFİKA CRUD İŞLEMLERİ --- */
        public IActionResult Sertifika()
        {
            var degerler = sertifikaRepository.List();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SertifikaEkle(Sertifikalarim sertifikalarim)
        {
            sertifikaRepository.Add(sertifikalarim);
            _alertHelper.SweetAlertShow("Sertifika", "Eklendi");
            return RedirectToAction("Sertifika", "Admin");
        }
        public IActionResult SertifikaSil(int id)
        {
            Sertifikalarim sertifikalarim = sertifikaRepository.Get(id);
            sertifikaRepository.Delete(sertifikalarim);
            _alertHelper.SweetAlertShow("Sertifika", "Silindi");
            return RedirectToAction("Sertifika", "Admin");
        }
        [HttpGet]
        public IActionResult SertifikaGuncelle(int id)
        {
            Sertifikalarim sertifikalarim = sertifikaRepository.Get(id);
            return View(sertifikalarim);
        }
        [HttpPost]
        public IActionResult SertifikaGuncelle(Sertifikalarim sertifikalarim)
        {
            Sertifikalarim temp = sertifikaRepository.Get(sertifikalarim.SertifikalarimId);
            temp.Aciklama = sertifikalarim.Aciklama;
            temp.Tarih = sertifikalarim.Tarih;
            sertifikaRepository.Update(temp);
            _alertHelper.SweetAlertShow("Sertifika", "Guncellendi");
            return RedirectToAction("Sertifika", "Admin");
        }
        /* --- SERTİFİKA CRUD İŞLEMLERİ --- */

        /***********************************/

        /* --- İLETİŞİM CRUD İŞLEMLERİ --- */
        public IActionResult Iletisim()
        {
            var degerler = iletisimRepository.List();
            return View(degerler);
        }
        public IActionResult IletisimSil(int id)
        {
            Iletisim iletisim = iletisimRepository.Get(id);
            iletisimRepository.Delete(iletisim);
            _alertHelper.SweetAlertShow("Iletisim", "Silindi");
            return RedirectToAction("Iletisim", "Admin");
        }
        /* --- İLETİŞİM CRUD İŞLEMLERİ --- */

        /***********************************/

        /* --- HOBİLERİM CRUD İŞLEMLERİ --- */
        public IActionResult Hobiler()
        {
            var degerler = hobiRepository.List();
            return View(degerler);
        }
        [HttpPost]
        public IActionResult HobilerGuncelle(Hobilerim hobilerim)
        {
            Hobilerim temp = hobiRepository.Get(hobilerim.HobilerimId);
            temp.Aciklama1 = hobilerim.Aciklama1;
            temp.Aciklama2 = hobilerim.Aciklama2;
            hobiRepository.Update(temp);
            _alertHelper.SweetAlertShow("Hobiler", "Guncellendi");
            return RedirectToAction("Hobiler", "Admin");
        }
        /* --- HOBİLERİM CRUD İŞLEMLERİ --- */

        /***********************************/

        /* --- KULLANICI CRUD İŞLEMLERİ --- */
        public IActionResult Kullanici()
        {
            var degerler = _context.Users.ToList();
            return View(degerler);
        }
        public IActionResult KullaniciSil(int id)
        {
            AppUser appUser = _context.Users.Find(id);
            _context.Users.Remove(appUser);
            _context.SaveChanges();
            _alertHelper.SweetAlertShow("Kullanici", "Silindi");
            return RedirectToAction("Kullanici", "Admin");
        }
        /* --- KULLANICI CRUD İŞLEMLERİ --- */

        /***********************************/
    }
}
