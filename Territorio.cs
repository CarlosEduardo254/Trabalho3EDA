using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho3EDA
{
    internal class Territorio
    {
        public string Rei { get; set; }
        public List<string> Vassalos { get; set; }

        public Territorio(string rei)
        {
            Rei = rei;
            Vassalos = new List<string> { rei };
        }


        public void adicionarVassalo(string nome)
        {
            Vassalos.Add(nome);
        }

        public int numeroVassalos()
        {
            return Vassalos.Count;
        }
    }
}
