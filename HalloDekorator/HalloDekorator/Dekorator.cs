namespace HalloDekorator
{
    internal interface IComponent
    {
        string Beschreibung { get; }
        decimal Preis { get; }
    }

    class Pizza : IComponent
    {
        public string Beschreibung => "Pizza";

        public decimal Preis => 6m;
    }

    class Brot : IComponent
    {
        public string Beschreibung => "Brot";

        public decimal Preis => 4m;
    }

    abstract class Dekorator : IComponent
    {
        protected IComponent parent;

        protected Dekorator(IComponent parent)
        {
            this.parent = parent;
        }

        public abstract string Beschreibung { get; }

        public abstract decimal Preis { get; }
    }

    class Käse : Dekorator
    {
        public Käse(IComponent parent) : base(parent)
        { }

        public override string Beschreibung => parent.Beschreibung + " Käse";

        public override decimal Preis => parent.Preis + 1.5m;
    }

    class Salami : Dekorator
    {
        public Salami(IComponent parent) : base(parent)
        { }

        public override string Beschreibung => parent.Beschreibung + " Salami";

        public override decimal Preis => parent.Preis + 3.7m;
    }
}
