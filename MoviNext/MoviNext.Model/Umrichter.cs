namespace MoviNext.Model
{
    public class Umrichter : Hardware
    {
        public double Spannung { get; set; }
        public SpannungsEinheit SpannungsEinheit { get; set; }
        public double Leistung { get; set; }
        public LeistungsEinheit LeistungsEinheit { get; set; }
        public double Frequenz { get; set; }
        public FrequenzEinheit FrequenzEinheit { get; set; }
        public string? UmrichterParameter { get; set; }

        public virtual Steuerung? Steuerung { get; set; }
        public virtual ICollection<Subkomponente> Subkomponenten { get; set; } = new HashSet<Subkomponente>();
    }
}