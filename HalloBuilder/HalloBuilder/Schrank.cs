namespace HalloBuilder
{
    internal class Schrank
    {
        public int AnzTüren { get; private set; }
        public int AnzBöden { get; private set; }
        public string Farbe { get; private set; }
        public Oberfläche Oberfläche { get; private set; }
        public bool Kleiderstange { get; private set; }

        private Schrank()
        { }

        public class SchrankBuilder
        {
            private Schrank toBuild = new Schrank();

            public SchrankBuilder SetAnzTüren(int anzahl)
            {
                if (anzahl < 2 || anzahl > 7)
                    throw new ArgumentException("Es sind nur min 2 oder max 7 Türen erlaubt");

                toBuild.AnzTüren = anzahl;

                return this;
            }

            public SchrankBuilder SetAnzBöden(int anzahl)
            {
                if (anzahl < 0 || anzahl > 6)
                    throw new ArgumentException("Es sind nur min 0 oder max 6 Böden erlaubt");

                toBuild.AnzBöden = anzahl;

                return this;
            }

            public SchrankBuilder SetOberfläche(Oberfläche oberfläche)
            {
                if (!string.IsNullOrWhiteSpace(toBuild.Farbe) && oberfläche != Oberfläche.Lackiert)
                    throw new ArgumentException("Keine Farbe bei Natur/Gewachst");

                toBuild.Oberfläche = oberfläche;
                return this;
            }

            public SchrankBuilder SetFarbe(string farbe)
            {
                if (toBuild.Oberfläche != Oberfläche.Lackiert)
                    throw new ArgumentException("Keine Farbe bei Natur/Gewachst");

                toBuild.Farbe = farbe;
                return this;
            }

            public Schrank Create()
            {
                return toBuild;
            }
        }

    }

    enum Oberfläche
    {
        Natur,
        Gewachst,
        Lackiert
    }
}
