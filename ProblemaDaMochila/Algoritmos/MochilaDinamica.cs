// Autores: Igor Christofer Eisenhut e
//          Manoella Marcondes Junkes

using ProblemaDaMochila.Estruturas;
using System;
using System.Linq;

namespace ProblemaDaMochila.Algoritmos
{
    public class MochilaDinamica : IAlgoritmoMochila
    {
        private int[,] matriz;

        public int CalcularValorMaximo(Item[] itens, int capacidadeMochila)
        {
            itens = itens
                .OrderBy(x => x.Peso)
                .ToArray();

            matriz = new int[itens.Length + 1, capacidadeMochila + 1];

            return CalcularValorMaximoDinamico(itens, capacidadeMochila);
        }

        private int CalcularValorMaximoDinamico(Item[] itens, int capacidadeMochila)
        {
            for (int i = 1; i <= itens.Length; i++)
            {
                var itemAtual = itens[i - 1];

                for (int j = 1; j <= capacidadeMochila; j++)
                {
                    if (itemAtual.Peso > j)
                    {
                        matriz[i, j] = matriz[i - 1, j];
                    }
                    else
                    {
                        var usa = itemAtual.Valor + matriz[i - 1, j - itemAtual.Peso];
                        var naoUsa = matriz[i - 1, j];

                        matriz[i, j] = Math.Max(usa, naoUsa);
                    }
                }
            }

            return matriz[itens.Length, capacidadeMochila];
        }
    }
}
