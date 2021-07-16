using Balanceador_de_Carga.Services;
using System;
using Xunit;

namespace Balancedor_de_Carga_Test.Services
{
    [Collection("Sequential")]
    public class GerenciarServidoresTest
    {
        [Fact] // Método para verificar a leitura do arquivo inicial e buscar o valor de uma linha
        public void LerAquivoTest()
        {
            Console.WriteLine("Iniciando teste ler arquivo");
            GerenciarServidores gerenciar = new GerenciarServidores();

            gerenciar.LerAquivo();
            gerenciar.DefinirQtdUsuariosAlocar(2);

            Assert.True(gerenciar.ConteudoArquivo.Count > 0);
            Assert.Equal(1, gerenciar.quantidadeUsuariosAlocar);
        }
    }
}
