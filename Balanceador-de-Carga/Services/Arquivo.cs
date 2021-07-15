using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Balanceador_de_Carga.Services
{
    class Arquivo
    {
        public List<int> LerArquivo(string caminhoArquivo)
        {
            List<int> linhas = new List<int>();

            if (!File.Exists(caminhoArquivo))
            {
                Console.WriteLine($"\nArquivo não encontrado. Favor verificar o caminho do arquivo");
                return linhas;
            }

            try
            {
                Console.WriteLine("\n Iniciando leitura do arquivo...");
                string[] conteudoArquivo = File.ReadAllLines(caminhoArquivo);

                for (int i = 0; i < conteudoArquivo.Length; i++)
                {
                    if (int.TryParse(conteudoArquivo[i], out int result))
                        linhas.Add(result);
                    else
                        Console.WriteLine($"O valor da linha [{i}] - {conteudoArquivo[i]} será desconsiderado. Não é numérico");
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine($"\nErro ao ler o arquivo. MOTIVO: {ex.Message}");
            }

            if (!ValidarArquivo(linhas))
                return null;
            else
                return linhas;
        }

        private bool ValidarArquivo(List<int> conteudoArquivo)
        {
            Validador validador = new Validador();
            string erro = validador.ValidarArquivoEntrada(conteudoArquivo);

            if (!string.IsNullOrEmpty(erro))
                Console.WriteLine(erro);

            return string.IsNullOrEmpty(erro);
        }

        public void EscreverArquivo(string caminhoSolvarArquivo, List<string> valoresParaEscrita = null)
        {
            if (valoresParaEscrita == null || valoresParaEscrita.Count == 0)
            {
                Console.WriteLine("Não há conteúdo para gravar, arquivo vazio ou inexistente");
                return;
            }

            using (StreamWriter sw = new StreamWriter(DefinirNomeArquivo(caminhoSolvarArquivo)))
            {
                try
                {
                    foreach (string item in valoresParaEscrita)
                        sw.WriteLine(item.Trim());

                    Console.WriteLine("Arquivo gravado com suceso!");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"\nErro ao gravar o arquivo. MOTIVO: {ex.Message}");
                }
            }
        }

        private string DefinirNomeArquivo(string caminhoArquivo)
        {
            int num = 0;
            string novoNome = caminhoArquivo.Replace(".txt", "").Trim() + ".txt";

            while (File.Exists(novoNome))
            {
                num++;
                novoNome = string.Concat(caminhoArquivo.Replace(".txt", ""), " (", num, ").txt");
            }

            return novoNome;
        }
    }
}
