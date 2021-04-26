// Autores: Igor Christofer Eisenhut e
//          Manoella Marcondes Junkes

using ProblemaDaMochila.Estruturas;
using System;
using System.Linq;

namespace ProblemaDaMochila.Algoritmos
{
    public class MochilaRecursiva : IAlgoritmoMochila
    {
        public int CalcularValorMaximo(Item[] itens, int capacidadeMochila)
        {
            itens = itens
                .OrderBy(x => x.Peso)
                .ToArray();

            return CalcularValorMaximoRecursivo(itens, itens.Length - 1, capacidadeMochila);
        }

        private int CalcularValorMaximoRecursivo(Item[] itens, int indiceAtual, int capacidadeRestante)
        {
            if (indiceAtual < 0 || capacidadeRestante == 0)
                return 0;

            var itemAtual = itens[indiceAtual];

            if (itemAtual.Peso > capacidadeRestante)
            {
                return CalcularValorMaximoRecursivo(itens,  indiceAtual - 1, capacidadeRestante);
            }
            else
            {
                var usa = itemAtual.Valor + CalcularValorMaximoRecursivo(itens, indiceAtual - 1, capacidadeRestante - itemAtual.Peso);

                var naoUsa = CalcularValorMaximoRecursivo(itens, indiceAtual - 1, capacidadeRestante);

                return Math.Max(usa, naoUsa);
            }
        }
    }
}
