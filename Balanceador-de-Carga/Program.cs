using Balanceador_de_Carga.Services;
using System;
using System.Collections.Generic;

namespace Balanceador_de_Carga
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("* Sistema balanceador de carga em Cloud   *");
            Console.WriteLine("* Desenvolvido por Lucas Amstalden        *");
            Console.WriteLine("*                                         *");
            Console.WriteLine("*******************************************");

            Console.WriteLine("\nDigite o caminho absoluto do arquivo [input.txt] ou então deixe em branco para utilizar o arquivo padrão.\nApós, digitel [Enter].");
            Console.WriteLine($"Obs: O arquivo padrão será criado no diretório:\n[{AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Arquivos"}]");

            Console.Write("\nCaminho:");
            string caminhoEscolhido = Console.ReadLine();

            GerenciarServidores gerenciarServers = new GerenciarServidores();
            gerenciarServers.ControlarServers(caminhoEscolhido);
            gerenciarServers.EncerrarAplicativo();

        }
    }
}
