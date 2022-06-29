// See https://aka.ms/new-console-template for more information
using HalloBuilder;

Console.WriteLine("Hello, World!");

Schrank schrank1 = new Schrank.SchrankBuilder()
                  .SetAnzBöden(4)
                  .SetAnzTüren(5)
                  .Create();

Schrank schrank2 = new Schrank.SchrankBuilder()
                  .SetAnzBöden(4)
                  .SetAnzTüren(5)
                  .SetOberfläche(Oberfläche.Lackiert)
                  .SetFarbe("blau")
                  .Create();
