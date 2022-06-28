namespace HalloEfCore.Model
{
    public class Kunde : Person
    {
        public string KdNummer { get; set; }
        public Mitarbeiter Ansprechpartner { get; set; }
    }
}
