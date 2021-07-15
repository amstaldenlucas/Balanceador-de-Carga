using Balanceador_de_Carga.Models;
using System;
using System.Collections.Generic;

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
        private int CustoTotalServidores = 0;

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
                CustoTotalServidores += listServidores.Count;

                listServidores = balancearServidores.DeletarServidoresInativos(listServidores);

                int indice = i + 2;
                DefinirQtdUsuariosAlocar(indice);

                listServidores = balancearServidores.DistribuirUsuariosNosServidores(listServidores, listUsers, UMax, i);

                string saida = string.Empty;

                foreach (Server servidor in listServidores)
                    saida += string.Concat(servidor.GetQtdUsuariosAlocados(), ",");

                if (saida.Length > 0)
                    saida = saida.Substring(0, saida.Length - 1);
                else
                    saida = "0";


                Console.WriteLine(saida);
                linhasParaSaida.Add(saida);
            }

            Console.WriteLine($"Custo Total = {CustoTotalServidores.ToString("C2")}");
            linhasParaSaida.Add($"Custo Total = {CustoTotalServidores.ToString("C2")}");

            Arquivo.EscreverArquivo(@"C:\Projects\Teste\Gravar\output.txt", linhasParaSaida);
        }

        private void DefinirQtdUsuariosAlocar(int indice)
        {
            this.listUsers.Clear();

            if (ConteudoArquivo.Count > indice)
            {
                int conteudo = ConteudoArquivo[indice];

                for (int i = 0; i < conteudo; i++)
                    this.listUsers.Add(new User(TTask, indice));
            }

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
