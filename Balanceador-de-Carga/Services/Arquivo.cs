using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Balanceador_de_Carga.Services
{
    class Arquivo
    {
        public string DiretorioLeitura;
        public string DiretorioGravar;
        private string DiretorioRaiz { get; set; }

        public Arquivo(string diretorioRaiz = null)
        {
            DiretorioRaiz = string.IsNullOrEmpty(diretorioRaiz) ? AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Arquivos" : diretorioRaiz;

            DiretorioLeitura = DiretorioRaiz + @"\Ler\input.txt";
            DiretorioGravar = DiretorioRaiz + @"\Gravar\output.txt";
        }
        public List<int> LerArquivo(string caminhoArquivo = null)
        {
            caminhoArquivo = string.IsNullOrEmpty(caminhoArquivo) ? DiretorioLeitura : caminhoArquivo;
            VerificarDiretorioRaiz();

            List<int> linhas = new List<int>();

            if (!File.Exists(caminhoArquivo))
            {
                Console.WriteLine($"\nArquivo não encontrado. Favor verificar o caminho do arquivo");
                return linhas;
            }

            try
            {
                Console.WriteLine("\nIniciando leitura do arquivo...");
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

        public void EscreverArquivo(string caminhoSalvarArquivo = null, List<string> valoresParaEscrita = null)
        {
            caminhoSalvarArquivo = string.IsNullOrEmpty(caminhoSalvarArquivo) ? DiretorioGravar : caminhoSalvarArquivo;
            if (valoresParaEscrita == null || valoresParaEscrita.Count == 0)
            {
                Console.WriteLine("Não há conteúdo para gravar, arquivo vazio ou inexistente");
                return;
            }

            using (StreamWriter sw = new StreamWriter(DefinirNomeArquivo(caminhoSalvarArquivo)))
            {
                try
                {
                    foreach (string item in valoresParaEscrita)
                        sw.WriteLine(item.Trim());

                    Console.WriteLine("\nArquivo gravado com suceso!");
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

        public void VerificarDiretorioRaiz()
        {
            string dirRaizLeitura = this.DiretorioRaiz;
            string dirRaizEscrita = dirRaizLeitura + @"\Gravar";

            dirRaizLeitura += @"\Ler";


            if (!Directory.Exists(dirRaizLeitura))
                Directory.CreateDirectory(dirRaizLeitura);

            if (!Directory.Exists(dirRaizEscrita))
                Directory.CreateDirectory(dirRaizEscrita);

            dirRaizLeitura += @"\input.txt";
            if (!File.Exists(dirRaizLeitura))
                EscreverArquivo(dirRaizLeitura, GetArquivoPadrao());
        }

        private List<string> GetArquivoPadrao()
        {
            List<string> arquivoPadrao = new List<string>
            {
                "4",
                "2",
                "1",
                "3",
                "0",
                "1",
                "0",
                "1"
            };

            return arquivoPadrao;
        }
    }
}
