using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortfolioTemplate.Models;

namespace PortfolioTemplate.Data
{
    public static class SeedData
    {
        // Identity User Bilgileri //
        private const string adminUser = "sinanozcelik";
        private const string adminPassword = "Sinan123.";

        public static async void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PortfolioDbContext>();

            if (context.Database.GetAppliedMigrations().Any())
            {
                context.Database.Migrate();
            }

            // Identity Context Bilgileri //
            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var user = await userManager.FindByNameAsync(adminUser);

            /* --- Admin Giriş Tablosu --- */
            if (user == null)
            {
                user = new AppUser
                {
                    NameSurname = "Sinan Özçelik",
                    UserName = adminUser,
                    Email = "info@sinanozcelik.com"
                };

                await userManager.CreateAsync(user, adminPassword);
            }

            if (context != null)
            {
                var hakkimda = new Hakkimda
                {
                    Ad = "CLARENCE",
                    Soyad = "TAYLOR",
                    Adres = "3542 BERRY STREET · CHEYENNE WELLS, CO 80810",
                    Telefon = "(317) 585-8468",
                    Mail = "NAME@EMAIL.COM",
                    Aciklama = "I am experienced in leveraging agile frameworks to provide a robust synopsis for high level overviews. Iterative approaches to corporate strategy foster collaborative thinking to further the overall value proposition.\r\n\r\n   ",
                    Resim = "Resim"
                };

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                /* --- Hakkimda Tablosu --- */
                if (!context.Hakkimda.Any())
                {
                    context.Hakkimda.Add(hakkimda);
                    context.SaveChanges();
                }
                /* --- Sosyal Medya Tablosu --- */
                if (!context.SosyalMedya.Any())
                {
                    context.SosyalMedya.AddRange(
                        new SosyalMedya
                        {
                            Ad = "LinkedIn",
                            Link = "#",
                            Icon = "fa-linkedin-in",
                            HakkimdaId = context.Hakkimda.First().HakkimdaId
                        });
                    context.SosyalMedya.AddRange(
                        new SosyalMedya
                        {
                            Ad = "GitHub",
                            Link = "#",
                            Icon = "fa-github",
                            HakkimdaId = context.Hakkimda.First().HakkimdaId
                        });
                    context.SosyalMedya.AddRange(
                        new SosyalMedya
                        {
                            Ad = "Twitter",
                            Link = "#",
                            Icon = "fa-twitter",
                            HakkimdaId = context.Hakkimda.First().HakkimdaId
                        });
                    context.SosyalMedya.AddRange(
                        new SosyalMedya
                        {
                            Ad = "Facebook",
                            Link = "#",
                            Icon = "fa-facebook",
                            HakkimdaId = context.Hakkimda.First().HakkimdaId
                        });
                    context.SaveChanges();
                }
                /* --- Deneyimler Tablosu --- */
                if (!context.Deneyimler.Any())
                {
                    context.Deneyimler.AddRange(
                        new Deneyimler
                        {
                            Baslik = "SENIOR WEB DEVELOPER",
                            AltBaslik = "INTELITEC SOLUTIONS",
                            Aciklama = "Bring to the table win-win survival strategies to ensure proactive domination. At the end of the day, going forward, a new normal that has evolved from generation X is on the runway heading towards a streamlined cloud solution. User generated content in real-time will have multiple touchpoints for offshoring.",
                            Tarih = DateTime.Now
                        });
                    context.Deneyimler.AddRange(
                        new Deneyimler
                        {
                            Baslik = "WEB DEVELOPER",
                            AltBaslik = "INTELITEC SOLUTIONS",
                            Aciklama = "Capitalize on low hanging fruit to identify a ballpark value added activity to beta test. Override the digital divide with additional clickthroughs from DevOps. Nanotechnology immersion along the information highway will close the loop on focusing solely on the bottom line.",
                            Tarih = DateTime.Now
                        });
                    context.Deneyimler.AddRange(
                        new Deneyimler
                        {
                            Baslik = "JUNIOR WEB DESIGNER",
                            AltBaslik = "SHOUT! MEDIA PRODUCTIONS",
                            Aciklama = "Podcasting operational change management inside of workflows to establish a framework. Taking seamless key performance indicators offline to maximise the long tail. Keeping your eye on the ball while performing a deep dive on the start-up mentality to derive convergence on cross-platform integration.",
                            Tarih = DateTime.Now
                        });
                    context.Deneyimler.AddRange(
                        new Deneyimler
                        {
                            Baslik = "WEB DESIGN INTERN",
                            AltBaslik = "SHOUT! MEDIA PRODUCTIONS",
                            Aciklama = "Collaboratively administrate empowered markets via plug-and-play networks. Dynamically procrastinate B2C users after installed base benefits. Dramatically visualize customer directed convergence without revolutionary ROI.",
                            Tarih = DateTime.Now
                        });
                    context.SaveChanges();
                }
                /* --- Eğitim Tablosu --- */
                if (!context.Egitim.Any())
                {
                    context.Egitim.AddRange(
                        new Egitim
                        {
                            Baslik = "UNIVERSITY OF COLORADO BOULDER",
                            AltBaslik1 = "BACHELOR OF SCIENCE",
                            AltBaslik2 = "Computer Science - Web Development Track",
                            GNO = "3.23",
                            Tarih = DateTime.Now
                        });
                    context.Egitim.AddRange(
                        new Egitim
                        {
                            Baslik = "JAMES BUCHANAN HIGH SCHOOL",
                            AltBaslik1 = "TECHNOLOGY MAGNET PROGRAM",
                            AltBaslik2 = "Computer Science - Web Development Track",
                            GNO = "3.56",
                            Tarih = DateTime.Now
                        });
                    context.SaveChanges();
                }
                /* --- Yeteneklerim Tablosu --- */
                if (!context.Yeteneklerim.Any())
                {
                    context.Yeteneklerim.AddRange(
                        new Yeteneklerim
                        {
                            Yetenek = "Mobile-First, Responsive Design",
                            Oran = 100
                        });
                    context.Yeteneklerim.AddRange(
                       new Yeteneklerim
                       {
                           Yetenek = "Cross Browser Testing & Debugging",
                           Oran = 80
                       });
                    context.Yeteneklerim.AddRange(
                       new Yeteneklerim
                       {
                           Yetenek = "Cross Functional Teams",
                           Oran = 60
                       });
                    context.Yeteneklerim.AddRange(
                       new Yeteneklerim
                       {
                           Yetenek = "Agile Development & Scrum",
                           Oran = 30
                       });
                    context.SaveChanges();
                }
                /* --- Hobilerim Tablosu --- */
                if (!context.Hobilerim.Any())
                {
                    context.Hobilerim.AddRange(
                        new Hobilerim
                        {
                            Aciklama1 = "Apart from being a web developer, I enjoy most of my time being outdoors. In the winter, I am an avid skier and novice ice climber. During the warmer months here in Colorado, I enjoy mountain biking, free climbing, and kayaking.",
                            Aciklama2 = "When forced indoors, I follow a number of sci-fi and fantasy genre movies and television shows, I am an aspiring chef, and I spend a large amount of my free time exploring the latest technology advancements in the front-end web development world."
                        });
                    context.SaveChanges();
                }
                /* --- Sertifikalarım Tablosu --- */
                if (!context.Sertifikalarim.Any())
                {
                    context.Sertifikalarim.AddRange(
                        new Sertifikalarim
                        {
                            Aciklama = "Google Analytics Certified Developer",
                            Tarih = DateTime.Now
                        });
                    context.Sertifikalarim.AddRange(
                        new Sertifikalarim
                        {
                            Aciklama = "Mobile Web Specialist - Google Certification",
                            Tarih = DateTime.Now
                        });
                    context.Sertifikalarim.AddRange(
                        new Sertifikalarim
                        {
                            Aciklama = "1 st Place - University of Colorado Boulder - Emerging Tech Competition 2009",
                            Tarih = DateTime.Now
                        });
                    context.Sertifikalarim.AddRange(
                        new Sertifikalarim
                        {
                            Aciklama = "1 st Place - University of Colorado Boulder - Adobe Creative Jam 2008 (UI Design Category)",
                            Tarih = DateTime.Now
                        });
                    context.Sertifikalarim.AddRange(
                        new Sertifikalarim
                        {
                            Aciklama = "2 nd Place - University of Colorado Boulder - Emerging Tech Competition 2008",
                            Tarih = DateTime.Now
                        });
                    context.Sertifikalarim.AddRange(
                        new Sertifikalarim
                        {
                            Aciklama = "1 st Place - James Buchanan High School - Hackathon 2006",
                            Tarih = DateTime.Now
                        });
                    context.Sertifikalarim.AddRange(
                        new Sertifikalarim
                        {
                            Aciklama = "3 rd Place - James Buchanan High School - Hackathon 2005",
                            Tarih = DateTime.Now
                        });
                    context.SaveChanges();
                }
                /* --- İletişim Tablosu --- */
                if (!context.Iletisim.Any())
                {
                    context.Iletisim.AddRange(
                        new Iletisim
                        {
                            AdSoyad = "Sinan Özçelik",
                            Mail = "info@sinanozcelik.com",
                            Konu = "Örnek Konu Başlığı",
                            Mesaj = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Tarih = DateTime.Now
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
