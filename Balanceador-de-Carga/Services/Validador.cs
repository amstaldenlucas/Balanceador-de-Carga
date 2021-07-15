using System;
using System.Collections.Generic;
using System.Text;

namespace Balanceador_de_Carga.Services
{
    class Validador
    {
        const Int16 MENOR_VALOR_TASK = 1;
        const Int16 MAIOR_VALOR_TASK = 10;
        const Int16 MENOR_VALOR_USUARIOS = 1;
        const Int16 MAIOR_VALOR_USUARIOS = 10;

        public string ValidarArquivoEntrada(List<int> valoresArquivo)
        {
            string erro = string.Empty;

            if (valoresArquivo[0] < MENOR_VALOR_TASK || valoresArquivo[0] > MAIOR_VALOR_TASK)
                erro += $"\nO valor [{valoresArquivo[0]}] da linha [1]-(TTask) estava fora do permitido. Menor valor = 1 e maior valor = 10;";

            if (valoresArquivo[1] < MENOR_VALOR_USUARIOS || valoresArquivo[1] > MAIOR_VALOR_USUARIOS)
                erro += $"\nO valor [{valoresArquivo[1]}] da linha [2]-(UMax) estava fora do permitido. Menor valor = 1 e maior valor = 10;";

            return erro;
        }
    }
}
