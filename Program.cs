using static Trabalho3EDA.Game;

namespace Trabalho3EDA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameUniaoBusca game = new GameUniaoBusca();

            // Adiciona territórios com seus respectivos reis
            game.AdicionarTerritorio("Rei Arthur");
            game.AdicionarTerritorio("Rei Leonidas");

            // Adiciona vassalos aos territórios
            game.AdicionarVassalo("Rei Arthur", "Sir Lancelot");
            game.AdicionarVassalo("Rei Arthur", "Sir Gawain");
            game.AdicionarVassalo("Rei Leonidas", "Espartano 1");
            game.AdicionarVassalo("Rei Leonidas", "Espartano 2");

            // Une territórios
            game.Union("Rei Arthur", "Rei Leonidas");

            // Verifica se os vassalos estão no mesmo território
            Console.WriteLine(game.Conexao("Sir Lancelot", "Espartano 1")); // True
            Console.WriteLine(game.Conexao("Sir Gawain", "Espartano 2"));   // True

            // Obtém e imprime a lista de vassalos de "Rei Arthur"
            List<string> vassalos = game.ImprimirVassalos("Rei Arthur");
            Console.WriteLine("Vassalos de Rei Arthur após união:");
            foreach (string vassalo in vassalos)
            {
                Console.WriteLine(vassalo);
            }
        }
    }
}
