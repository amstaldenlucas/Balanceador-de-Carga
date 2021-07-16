using Balanceador_de_Carga.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Balancedor_de_Carga_Test.Services
{
    [Collection("Sequential")]
    public class ArquivoTest
    {
        Arquivo arquivo = new Arquivo();

        [Fact] // Método para verificar o construtor 
        public void VerificarMetodoConstrutor()
        {
            Console.WriteLine("Iniciando teste para Verificar Metodo Construtor Classe Arquivo");
            string dirRaiz = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Arquivos";
            string dirLeitura = dirRaiz + @"\Ler\input.txt";

            Arquivo newArquivo = new Arquivo(dirRaiz);

            Assert.Equal(dirLeitura, newArquivo.DiretorioLeitura);
        }

        [Fact] // Método para verificar se a class consegue escrever um arquivo
        public void EscreverArquivoTest()
        {
            arquivo.VerificarDiretorioRaiz();

            string arquivoInput = arquivo.DiretorioLeitura;
            Assert.True(File.Exists(arquivoInput));

            string pastaRaiz = arquivo.DiretorioLeitura.Replace("input.txt", "").Replace("Ler", "");
            if (Directory.Exists(pastaRaiz))
                Directory.Delete(pastaRaiz, true);
        }

        [Fact] // Método para verificar se a class consegue realizar a leitura em um arquivo
        public void LerArquivoTest()
        {
            arquivo.VerificarDiretorioRaiz();
            
            int aux = arquivo.LerArquivo().Count;

            Assert.True(aux > 0);

            string pastaRaiz = arquivo.DiretorioLeitura.Replace("input.txt", "").Replace("Ler", "");
            if (Directory.Exists(pastaRaiz))
                Directory.Delete(pastaRaiz, true);
        }
    }
}
