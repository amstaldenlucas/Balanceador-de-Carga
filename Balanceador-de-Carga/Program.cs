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
            Console.WriteLine("Desenvolvido por Lucas Amstalden");
            GerenciarServidores gerenciarServers = new GerenciarServidores();
            gerenciarServers.ControlarServers();
            gerenciarServers.EncerrarAplicativo();

        }
    }
}
