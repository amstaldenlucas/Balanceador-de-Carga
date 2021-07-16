using Balanceador_de_Carga.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Balancedor_de_Carga_Test.Services
{
    public class GerenciarServidoresTest
    {
        [Fact]
        public void LerAquivoTest()
        {
            GerenciarServidores gerenciar = new GerenciarServidores();
            gerenciar.LerAquivo();

            Assert.True(gerenciar.ConteudoArquivo.Count > 0);
        }

        [Fact]
        public void DefinirQtdUsuariosAlocarTest()
        {
            GerenciarServidores gerenciarServidores = new GerenciarServidores();

            gerenciarServidores.LerAquivo();
            //gerenciarServidores.ConteudoArquivo.Clear();
            gerenciarServidores.ConteudoArquivo = new List<int>
            {
                2,
                3
            };

            gerenciarServidores.DefinirQtdUsuariosAlocar(1);
            Assert.Equal(3, gerenciarServidores.QuantidadeUsuariosAlocar);
        }
    }
}
