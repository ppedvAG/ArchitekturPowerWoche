// See https://aka.ms/new-console-template for more information
using HalloDekorator;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Hello, World!");

var meinBrot = new Käse(new Brot());
Console.WriteLine($"{meinBrot.Beschreibung} {meinBrot.Preis:c}");

var meinPizza = new Salami( new Käse(new Käse(new Pizza())));
Console.WriteLine($"{meinPizza.Beschreibung} {meinPizza.Preis:c}");