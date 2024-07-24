namespace PortfolioTemplate.Models
{
    public class Deneyimler
    {
        public int DeneyimlerId { get; set; }
        public string? Baslik { get; set; }
        public string? AltBaslik { get; set; }
        public string? Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}
