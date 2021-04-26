// Autores: Igor Christofer Eisenhut e
//          Manoella Marcondes Junkes

using ProblemaDaMochila.Estruturas;

namespace ProblemaDaMochila.Algoritmos
{
    public interface IAlgoritmoMochila
    {
        int CalcularValorMaximo(Item[] itens, int capacidadeMochila);
    }
}
