namespace PortfolioTemplate.Models
{
    public class SosyalMedya
    {
        public int SosyalMedyaId { get; set; }
        public string? Ad { get; set; }
        public string? Link { get; set; }
        public string? Icon { get; set; }

        // İlişkiyi temsil etmek için
        public Hakkimda? Hakkimda { get; set; }
        public int HakkimdaId { get; set; } = 1;
    }
}
