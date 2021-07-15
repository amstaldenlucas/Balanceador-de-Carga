using Balanceador_de_Carga.Services;
using System;
using System.Collections.Generic;

namespace Balanceador_de_Carga
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema balanceador de carga em Cloud");

            GerenciarServidores gerenciarServers = new GerenciarServidores(@"C:\Projects\Teste\input.txt");
            gerenciarServers.ControlarServers();

            //Arquivo arquivo = new Arquivo();

            //List<int> conteudoArquivo = arquivo.LerArquivo(@"C:\Projects\Teste\arquivo-inicial.txt");

            //Validador validador = new Validador();
            //string errosEncontrados = validador.ValidarArquivoEntrada(conteudoArquivo);
            //if (!string.IsNullOrEmpty(errosEncontrados))
            //    Console.WriteLine("\n Erros encontrados:" + errosEncontrados);

            //Console.WriteLine("Leitura feita...");

            //for (int i = 0; i < conteudoArquivo.Count; i++)
            //{
            //    Console.WriteLine($"Linha [{i}] - Valor [{conteudoArquivo[i]}]");
            //}





            //List<string> teste = new List<string>();
            //teste.Add("Teste 1");
            //teste.Add("Teste 2");
            //teste.Add("Teste 3");
            //teste.Add("Teste 4");

            //arquivo.EscreverArquivo(@"C:\Projects\Teste\Gravar\arquivo", teste);
        }
    }
}
