// See https://aka.ms/new-console-template for more information
using MoviNext.HardwareService;
using MoviNext.Model;

Console.WriteLine("Hello, World!");

//DI manuell via Project Reference
var hs = new HardwareService(new MoviNext.Data.EfCore.EfRepository());

Console.WriteLine($"Most Leistung: {hs.GetUmrichterWithMostLeistung().Name}");


foreach (var umr in hs.Repository.Query<Umrichter>().Where(x => x.Leistung > 2).ToList())
{
    Console.WriteLine(umr.Name);
    Console.WriteLine($"Steuerung: {umr.Steuerung.Name}");
	Console.WriteLine("Subkomponenten:");
	foreach (var item in umr.Subkomponenten)
	{
		Console.WriteLine($"\t{item.Name}");
	}
}


