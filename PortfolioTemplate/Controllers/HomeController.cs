using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioTemplate.Data;
using PortfolioTemplate.Models;
using PortfolioTemplate.Repositories;
using System.Diagnostics;

namespace PortfolioTemplate.Controllers
{
    public class HomeController : Controller
    {
        // SweetAlert
        private readonly AlertHelper _alertHelper;
        // --- Veritabaný Baðlantý Bilgisi --- //
        private readonly PortfolioDbContext _context;
        public HomeController(PortfolioDbContext context)
        {
            _context = context;
            // SweetAlert
            _alertHelper = new AlertHelper(this);
        }
        // --- Veritabaný Baðlantý Bilgisi --- //

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel
            {
                Hakkimda = await _context.Hakkimda.ToListAsync(),
                Deneyimler = await _context.Deneyimler.ToListAsync(),
                Egitim = await _context.Egitim.ToListAsync(),
                Yeteneklerim = await _context.Yeteneklerim.ToListAsync(),
                Hobilerim = await _context.Hobilerim.ToListAsync(),
                Sertifikalarim = await _context.Sertifikalarim.ToListAsync(),
                Iletisim = await _context.Iletisim.ToListAsync(),
                SosyalMedya = await _context.SosyalMedya.ToListAsync()
            };

            return View(viewModel);
        }

        public PartialViewResult Hakkimda()
        {
            return PartialView();
        }
        public PartialViewResult Deneyimler()
        {
            return PartialView();
        }
        public PartialViewResult Egitim()
        {
            return PartialView();
        }
        public PartialViewResult Yeteneklerim()
        {
            return PartialView();
        }
        public PartialViewResult Hobilerim()
        {
            return PartialView();
        }
        public PartialViewResult Sertifikalarim()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Iletisim(Iletisim iletisim)
        {
            iletisim.Tarih = DateTime.Now;
            _context.Iletisim.Add(iletisim);
            _context.SaveChanges();
            _alertHelper.SweetAlertShow("Mesajiniz", "Gonderildi");
            return RedirectToAction("Index", "Home");
        }
    }
}
