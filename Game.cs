using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho3EDA
{
    internal class Game
    {
        public class GameUniaoBusca
        {
            private Dictionary<string, string> parent;
            private Dictionary<string, Territorio> territorios;

            public GameUniaoBusca()
            {
                parent = new Dictionary<string, string>();
                territorios = new Dictionary<string, Territorio>();
            }

            public void AdicionarTerritorio(string rei)
            {
                if (!territorios.ContainsKey(rei))
                {
                    territorios[rei] = new Territorio(rei);
                    parent[rei] = rei;
                }
            }

            public void AdicionarVassalo(string rei, string vassalo)
            {
                if (territorios.ContainsKey(rei))
                {
                    territorios[rei].adicionarVassalo(vassalo);
                    parent[vassalo] = rei;
                }
                else
                {
                    Console.WriteLine($"Território com o Rei {rei} não foi encontrado.");
                }
            }

            public string Find(string vassalo)
            {
                if (!parent.ContainsKey(vassalo))
                {
                    throw new KeyNotFoundException($"O vassalo '{vassalo}' não está presente no dicionário.");
                }

                if (parent[vassalo] != vassalo)
                {
                    // Compressão de caminho
                    parent[vassalo] = Find(parent[vassalo]);
                }
                return parent[vassalo];
            }

            public void Union(string rei1, string rei2)
            {
                string root1 = Find(rei1);
                string root2 = Find(rei2);

                if (root1 == root2) return;

                // É selecionado o rei com mais vassalos para ser o novo representante
                if (territorios[root1].numeroVassalos() >= territorios[rei2].numeroVassalos())
                {
                    // Atualiza todos os vassalos de root2 para apontar para root1
                    foreach (string vassalo in territorios[root2].Vassalos)
                    {
                        parent[vassalo] = root1;
                    }

                    territorios[root1].Vassalos.AddRange(territorios[root2].Vassalos);
                    territorios.Remove(root2);
                }
                else
                {
                    // Atualiza todos os vassalos de root1 para apontar para root2
                    foreach (string vassalo in territorios[root1].Vassalos)
                    {
                        parent[vassalo] = root2;
                    }

                    territorios[root2].Vassalos.AddRange(territorios[root1].Vassalos);
                    territorios.Remove(root1);
                }
            }

            public bool Conexao(string vassalo1, string vassalo2)
            {
                if (!parent.ContainsKey(vassalo1) || !parent.ContainsKey(vassalo2))
                {
                    throw new KeyNotFoundException("Um ou ambos os vassalos não estão presentes no dicionário.");
                }

                return Find(vassalo1) == Find(vassalo2);
            }

            public List<string> ImprimirVassalos(string rei)
            {
                string root = Find(rei);
                if (territorios.ContainsKey(root))
                {
                    return territorios[root].Vassalos;
                }
                return new List<string>();
            }
        }
    }
}
