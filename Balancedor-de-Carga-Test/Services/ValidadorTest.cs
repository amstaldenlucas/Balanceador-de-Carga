using Balanceador_de_Carga.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Balancedor_de_Carga_Test.Services
{
    public class ValidadorTest
    {
        [Fact] // Método para verificar se o validador do arquivo entrada está correto
        public void ValidarArquivoEntradaTest()
        {
            List<int> arquivoPadrao = new List<int>
            {
                4,
                2,
                1,
                3,
                0,
                1,
                0,
                1
            };

            Validador validador = new Validador();

            Assert.True(string.IsNullOrEmpty(validador.ValidarArquivoEntrada(arquivoPadrao)));

            arquivoPadrao[0] = 11;
            Assert.True(!string.IsNullOrEmpty(validador.ValidarArquivoEntrada(arquivoPadrao)));

            arquivoPadrao[0] = 4;
            arquivoPadrao[1] = -1;
            Assert.True(!string.IsNullOrEmpty(validador.ValidarArquivoEntrada(arquivoPadrao)));
        }
    }
}
