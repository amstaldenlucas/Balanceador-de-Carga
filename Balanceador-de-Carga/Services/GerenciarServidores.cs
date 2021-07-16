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
        private int tTask = 0;
        private int uMax = 0;
        private int custoTotalServidores = 0;
        public int quantidadeUsuariosAlocar = 0;

        List<Server> listServidores = new List<Server>();
        List<User> listUsers = new List<User>();
        List<string> linhasParaSaida = new List<string>();

        public void ControlarServers(string caminhoArquivo = null)
        {
            BalancearServidores balancearServidores = new BalancearServidores();
            LerAquivo(caminhoArquivo);

            // Laço para ser executado até existir algum tick para ser executado.
            for (int i = 0; i < ticks; i++)
            {
                custoTotalServidores += listServidores.Count;

                // Deletar os servidores inativos
                listServidores = balancearServidores.DeletarServidoresInativos(listServidores, tTask);

                int indice = i + 2;
                DefinirQtdUsuariosAlocar(indice);

                // Distribuir e/ou remover os novos usuários dos servidores
                listServidores = balancearServidores.DistribuirUsuariosNosServidores(listServidores, listUsers, uMax, i);

                string saida = string.Empty;

                // Gravar a quantidade de servidores online com a quantidade de seus respectivos usuários.
                foreach (Server servidor in listServidores)
                    saida += string.Concat(servidor.GetQtdUsuariosAlocados(), ",");

                if (saida.Length > 0)
                    saida = saida.Substring(0, saida.Length - 1);
                else
                    saida = "0";

                Console.WriteLine(saida);
                linhasParaSaida.Add(saida);
            }

            Console.WriteLine($"{custoTotalServidores.ToString("D2")}");
            linhasParaSaida.Add($"{custoTotalServidores.ToString("D2")}");

            Arquivo.EscreverArquivo("", linhasParaSaida);
        }

        /// <summary>
        /// Definir quantidade de novos usuários para alocar.
        /// </summary>
        /// <param name="indice">Indice da linha atual</param>
        public void DefinirQtdUsuariosAlocar(int indice)
        {
            this.listUsers.Clear();

            if (ConteudoArquivo.Count > indice)
            {
                int conteudo = ConteudoArquivo[indice];

                for (int i = 0; i < conteudo; i++)
                    this.listUsers.Add(new User(tTask, indice));
            }

            quantidadeUsuariosAlocar = this.listUsers.Count;
        }

        /// <summary>
        /// Ler o arquivo atual
        /// </summary>
        /// <param name="caminhoArquivo">Caminho absoluto do arquivo</param>
        public void LerAquivo(string caminhoArquivo = null)
        {
            List<int> conteudoLido = Arquivo.LerArquivo(caminhoArquivo);

            if (conteudoLido == null)
                EncerrarAplicativo();

            this.ConteudoArquivo = conteudoLido;
            if (this.ConteudoArquivo.Count == 0)
                EncerrarAplicativo();

            this.tTask = ConteudoArquivo[0];
            this.uMax = ConteudoArquivo[1];
            this.ticks = (ConteudoArquivo.Count - 2) + tTask;
        }

        public void EncerrarAplicativo()
        {
            Console.WriteLine("\n------------------------------------------------------------------------");
            Console.WriteLine("Programa encerrado. Pressione qualquer tecla para finalizar!");
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
