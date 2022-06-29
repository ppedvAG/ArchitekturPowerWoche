// See https://aka.ms/new-console-template for more information
using HalloSingelton;

Console.WriteLine("Hello, World!");


Parallel.For(0, 10, i => Logger.Instance.Info($"HALLO {i}"));

Console.WriteLine("Ende");
Console.ReadLine();