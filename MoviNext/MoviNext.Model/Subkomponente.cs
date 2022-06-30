namespace MoviNext.Model
{
    public class Subkomponente : Hardware
    {
        public virtual Umrichter? Umrichter { get; set; }
        public string? SubkompoParameter { get; set; }

    }
}