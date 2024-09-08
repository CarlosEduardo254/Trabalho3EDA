using static Trabalho3EDA.Game;

namespace Trabalho3EDA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameUniaoBusca game = new GameUniaoBusca();
            int o = 0;

            while (o != 7)
            {
                Console.WriteLine("------------------------- MENU -------------------------");
                Console.WriteLine("\t[1] - Adicionar Território.");
                Console.WriteLine("\t[2] - Adicionar Vassalo.");
                Console.WriteLine("\t[3] - União de Territórios.");
                Console.WriteLine("\t[4] - Buscar Pessoa.");
                Console.WriteLine("\t[5] - Verificar se dois vassalos estão no mesmo território.");
                Console.WriteLine("\t[6] - Imprimir Território.");
                Console.WriteLine("\t[7] - Finalizar Jogo e mostrar o vencedor.");
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Escolha uma opção:");
                o = int.Parse(Console.ReadLine());

                switch (o)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do Rei do novo território:");
                        string novoRei = Console.ReadLine();
                        if (novoRei != null)
                        {
                            game.AdicionarTerritorio(novoRei);
                        }
                        else
                        {
                            Console.WriteLine("Erro ao tentar criar um novo território");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Digite o nome do Rei do território:");
                        string reiAddV = Console.ReadLine();
                        Console.WriteLine("Digite o nome do Vassalo que será adicionado:");
                        string novoVassalo = Console.ReadLine();

                        if (novoVassalo != null && reiAddV != null)
                        {
                            game.AdicionarVassalo(reiAddV, novoVassalo);
                        }
                        else
                        {
                            Console.WriteLine("Erro ao tentar adicionar um novo vassalo");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Digite o nome do rei do primeiro território:");
                        string rei1U = Console.ReadLine();
                        Console.WriteLine("Digite o nome do rei do segundo território:");
                        string rei2U = Console.ReadLine();

                        if (rei1U != null && rei2U != null)
                        {
                            game.Uniao(rei1U, rei2U);
                        }
                        else
                        {
                            Console.WriteLine("Erro ao tentar unir os territórios");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Digite o nome da pessoa que você quer buscar:");
                        string pessoaBuscada = Console.ReadLine();
                        string busca = game.Find(pessoaBuscada);

                        if(busca != null)
                        {
                            Console.WriteLine($"{pessoaBuscada} encontrado/a.");
                        } else
                        {
                            Console.WriteLine($"{pessoaBuscada} não encontrado.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Digite o nome do primeiro vassalo:");
                        string vassalo01 = Console.ReadLine();
                        Console.WriteLine("Digite o nome do segundo vassalo:");
                        string vassalo02 = Console.ReadLine();
                        if (game.Conexao(vassalo01, vassalo02))
                        {
                            Console.WriteLine($"O vassalo {vassalo01} está no mesmo território do vassalo {vassalo02}");
                        }
                        else
                        {
                            Console.WriteLine($"O vassalo {vassalo01} não está no mesmo território do vassalo {vassalo02}");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Digite o nome do rei do território que você deseja imprimir:");
                        string reiImp = Console.ReadLine();

                        List<string> vassalosImp = game.ImprimirVassalos(reiImp);
                        if (vassalosImp.Count > 0)
                        {
                            Console.WriteLine($"Vassalos de {reiImp}:");
                            foreach (string vassalo in vassalosImp)
                            {
                                Console.Write(vassalo + " - ");
                            }
                            Console.WriteLine();
                        }


                        break;
                    case 7:
                        List<string> reis = game.GetReis();
                        string reiComMaisVassalos = null;
                        int maiorNum = -1;
                        foreach (string territorio in reis)
                        {
                            int numeroDeVassalos = game.ContarVassalos(territorio);
                            Console.WriteLine($"Número de vassalos do Rei {territorio}: {numeroDeVassalos}");

                            if(numeroDeVassalos > maiorNum)
                            {
                                maiorNum = numeroDeVassalos;
                                reiComMaisVassalos = territorio;
                            }
                            
                        }
                        if (reiComMaisVassalos != null)
                        {
                            Console.WriteLine($"O Rei vencedor da Guerra é {reiComMaisVassalos} com {maiorNum} Vassalos");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Não há reis ou vassalos para comparar.");
                            return;
                        }
                    default:
                        Console.WriteLine("Insira um número dentre as opções do menu");
                        break;
                }
            }
        }
    }
}
