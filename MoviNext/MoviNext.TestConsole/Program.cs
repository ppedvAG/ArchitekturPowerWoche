// See https://aka.ms/new-console-template for more information
using Autofac;
using MoviNext.Data.EfCore;
using MoviNext.HardwareService;
using MoviNext.Model;
using MoviNext.Model.Contracts;

Console.WriteLine("Hello, World!");

//DI manuel via Project Reference
//var hs = new HardwareService(new MoviNext.Data.EfCore.EfRepository());

//DI manuel via Reflection
//var pfad = @"C:\Users\Fred\source\repos\ppedvAG\ArchitekturPowerWoche\MoviNext\MoviNext.Data.EfCore\bin\Debug\net6.0\MoviNext.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(pfad);
//var efRepoType = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//var repo = (IRepository)Activator.CreateInstance(efRepoType);
//var hs = new HardwareService(repo);

//DI per Autofac
var builder = new ContainerBuilder();
builder.RegisterType<EfRepository>().As<IRepository>();
var container =  builder.Build();

var hs = new HardwareService(container.Resolve<IRepository>());

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


