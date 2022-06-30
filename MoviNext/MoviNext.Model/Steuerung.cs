namespace MoviNext.Model
{
    public class Steuerung : Hardware
    {
        public byte[]? Prog { get; set; }
        public string? SteuerungsParameter { get; set; }

        public virtual ICollection<Umrichter> Umrichter { get; set; } = new HashSet<Umrichter>();
    }
}