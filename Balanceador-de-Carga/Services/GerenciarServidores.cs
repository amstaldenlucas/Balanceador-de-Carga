using Balanceador_de_Carga.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Balanceador_de_Carga.Services
{
    public class GerenciarServidores
    {
        public List<int> ConteudoArquivo;
        private Arquivo Arquivo = new Arquivo();

        private BalancearServidores BalancearServidores = new BalancearServidores();
        private int ticks = 0;
        private int TTask = 0;
        private int UMax = 0;
        private int CustoTotalServidores = 0;
        public int QuantidadeUsuariosAlocar = 0;

        List<Server> listServidores = new List<Server>();
        List<User> listUsers = new List<User>();
        List<string> linhasParaSaida = new List<string>();

        public void ControlarServers()
        {
            BalancearServidores balancearServidores = new BalancearServidores();
            LerAquivo();


            for (int i = 0; i < ticks; i++)
            {
                CustoTotalServidores += listServidores.Count;

                listServidores = balancearServidores.DeletarServidoresInativos(listServidores, TTask);

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

            Console.WriteLine($"{CustoTotalServidores.ToString("D2")}");
            linhasParaSaida.Add($"{CustoTotalServidores.ToString("D2")}");

            Arquivo.EscreverArquivo("", linhasParaSaida);
        }

        public void DefinirQtdUsuariosAlocar(int indice)
        {
            this.listUsers.Clear();

            if (ConteudoArquivo.Count > indice)
            {
                int conteudo = ConteudoArquivo[indice];

                for (int i = 0; i < conteudo; i++)
                    this.listUsers.Add(new User(TTask, indice));
            }

            QuantidadeUsuariosAlocar = this.listUsers.Count;
        }

        public void LerAquivo()
        {
            this.ConteudoArquivo = Arquivo.LerArquivo();
            this.TTask = ConteudoArquivo[0];
            this.UMax = ConteudoArquivo[1];
            this.ticks = (ConteudoArquivo.Count - 2) + TTask;
        }

        public void EncerrarAplicativo()
        {
            Console.WriteLine("\n------------------------------------------------------------------------");
            Console.WriteLine("Programa finalizado com suceso. Pressione qualquer tecla para finalizar!");
            Console.ReadLine();


            for (int i = 3; i > 0; i--)
            {
                Console.Write($"Fechando em {i}...\n");
                Thread.Sleep(1000);
            }

            Environment.Exit(0);
        }
    }
}
