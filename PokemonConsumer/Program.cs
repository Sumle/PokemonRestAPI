// See https://aka.ms/new-console-template for more information
using PokemonConsumer;

Console.WriteLine("Starting");

PokemonWorker myWorker = new PokemonWorker();
myWorker.DoWork();