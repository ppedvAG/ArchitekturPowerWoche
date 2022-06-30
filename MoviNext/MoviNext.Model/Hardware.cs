namespace MoviNext.Model
{
    public abstract class Hardware : Entity
    {
        public string Name { get; set; } = string.Empty;
        public int Version { get; set; }
        public string NetzAdr { get; set; } = string.Empty;
        public string? BasisParameter { get; set; }
    }
}