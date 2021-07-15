using Balanceador_de_Carga.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Balanceador_de_Carga.Services
{
    class GerenciarServidores
    {
        private string CaminhoArquivo;
        private List<int> ConteudoArquivo;
        private Arquivo Arquivo = new Arquivo();

        private BalancearServidores BalancearServidores = new BalancearServidores();
        private int ticks = 0;
        private int TTask = 0;
        private int UMax = 0;

        List<Server> listServidores = new List<Server>();
        List<User> listUsers = new List<User>();
        List<string> linhasParaSaida = new List<string>();

        public GerenciarServidores(string caminhoArquivo)
        {
            CaminhoArquivo = caminhoArquivo;
        }

        public void ControlarServers()
        {
            BalancearServidores balancearServidores = new BalancearServidores();
            LerAquivo();
            

            for (int i = 0; i < ticks; i++)
            {
                //int tickAtual = i++;
                if (i == 4)
                {
                    int teste = i;
                }

                listServidores = balancearServidores.DeletarServidoresInativos(listServidores);

                DefinirQtdUsuariosAlocar(ConteudoArquivo[i + 2], i);
                listServidores = balancearServidores.DistribuirUsuariosNosServidores(listServidores, listUsers, UMax, ticks);

                string saida = string.Empty;
                foreach (Server servidor in listServidores)
                {
                    saida += string.Concat(servidor.GetQtdUsuariosAlocados(), ",");
                }

                saida = saida.Substring(0, saida.Length - 1);

                //if (i + 1 < ticks)
                //    saida += "\n";

                Console.WriteLine(saida);
                linhasParaSaida.Add(saida);
            }

            linhasParaSaida.Add("0");
            linhasParaSaida.Add("Custo Total");

            Arquivo.EscreverArquivo(@"C:\Projects\Teste\Gravar\output.txt", linhasParaSaida);
        }

        private void DefinirQtdUsuariosAlocar(int qtdUsuarios, int id)
        {
            this.listUsers.Clear();

            for (int i = 0; i < qtdUsuarios; i++)
                this.listUsers.Add(new User(TTask, id));
        }

        private void LerAquivo()
        {
            this.ConteudoArquivo = Arquivo.LerArquivo(this.CaminhoArquivo);
            this.TTask = ConteudoArquivo[0];
            this.UMax = ConteudoArquivo[1];
            this.ticks = (ConteudoArquivo.Count - 2) + TTask;
        }


    }
}
