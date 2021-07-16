using Balanceador_de_Carga.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Balancedor_de_Carga_Test.Services
{
    [Collection("Sequential")]
    public class GerenciarServidoresTest
    {
        [Fact]
        public void LerAquivoTest()
        {
            Console.WriteLine("Iniciando teste ler arquivo");
            GerenciarServidores gerenciar = new GerenciarServidores();

            gerenciar.LerAquivo();
            gerenciar.DefinirQtdUsuariosAlocar(2);

            Assert.True(gerenciar.ConteudoArquivo.Count > 0);
            Assert.Equal(1, gerenciar.QuantidadeUsuariosAlocar);
        }
    }
}
