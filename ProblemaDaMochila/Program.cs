// Autores: Igor Christofer Eisenhut e
//          Manoella Marcondes Junkes

using ProblemaDaMochila.Algoritmos;
using ProblemaDaMochila.Estruturas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ProblemaDaMochila
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cronometro = new Stopwatch();
            var recursiva = new MochilaRecursiva();
            var dinamica = new MochilaDinamica();
            var valorMaximo = 0;

            Console.WriteLine("Indique a pasta que contém os arquivos de teste: ");
            var pasta = Console.ReadLine();

            foreach (var arquivo in Directory.GetFiles(pasta, "*.in"))
            {
                var (capacidadeMochila, itens) = ObterDadosArquivo(arquivo);

                Console.WriteLine();
                Console.WriteLine($"Arquivo {arquivo[(arquivo.LastIndexOf('\\') + 1)..]} ------------");
                Console.WriteLine();

                cronometro.Restart();
                valorMaximo = recursiva.CalcularValorMaximo(itens, capacidadeMochila);
                cronometro.Stop();

                Console.WriteLine("ABORDAGEM RECURSIVA");
                Console.WriteLine($"\tValor máximo: {valorMaximo}");
                Console.WriteLine($"\tTempo decorrido: {cronometro.ElapsedMilliseconds}ms");
                Console.WriteLine();

                cronometro.Restart();
                valorMaximo = dinamica.CalcularValorMaximo(itens, capacidadeMochila);
                cronometro.Stop();

                Console.WriteLine("ABORDAGEM DINÂMICA");
                Console.WriteLine($"\tValor máximo: {valorMaximo}");
                Console.WriteLine($"\tTempo decorrido: {cronometro.ElapsedMilliseconds}ms");
                Console.WriteLine();
            }
        }

        public static (int capacidadeMochila, Item[] itens) ObterDadosArquivo(string path)
        {
            var stream = File.OpenText(path);
            
            var capacidadeMochila = Convert.ToInt32(stream.ReadLine());
            var itens = new List<Item>();

            var numeroItem = 1;

            string linha;
            while((linha = stream.ReadLine()) != null)
            {
                var dados = linha.Split('\t');

                itens.Add(new Item(Convert.ToInt32(dados[0]), Convert.ToInt32(dados[1]), numeroItem++));
            }

            return (capacidadeMochila, itens.ToArray());
        }
    }
}
