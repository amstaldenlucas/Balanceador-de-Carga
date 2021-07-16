using System;
using System.Collections.Generic;
using System.IO;

namespace Balanceador_de_Carga.Services
{
    public class Arquivo
    {
        public string DiretorioLeitura;
        public string DiretorioGravar;
        private string DiretorioRaiz { get; set; }

        // Instanciando um novo obj Arquivo
        public Arquivo(string diretorioRaiz = null)
        {
            DiretorioRaiz = string.IsNullOrEmpty(diretorioRaiz) ? AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Arquivos" : diretorioRaiz;

            DiretorioLeitura = DiretorioRaiz + @"\Ler\input.txt";
            DiretorioGravar = DiretorioRaiz + @"\Gravar\output.txt";
        }

        /// <summary>
        /// Ler um arquivo
        /// </summary>
        /// <param name="caminhoArquivo">Caminho do arquivo para leitura</param>
        /// <returns>Lista de valores em inteiro (1 item para cada linha do arquivo)</returns>
        public List<int> LerArquivo(string caminhoArquivo = null)
        {
            // Definir o diretório do arquivo para ler
            caminhoArquivo = string.IsNullOrEmpty(caminhoArquivo) ? DiretorioLeitura : caminhoArquivo;

            // Caso não existir o diretório para leitura, criar um novo
            VerificarDiretorioRaiz(caminhoArquivo);

            List<int> linhas = new List<int>();

            if (!File.Exists(caminhoArquivo))
            {
                Console.WriteLine($"\nArquivo não encontrado. Favor verificar o caminho absoluto");
                return linhas;
            }

            // Ler as linhas do arquivo.
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


        /// <summary>
        /// Verificar se as informações existentes no arquivo são válidas.
        /// </summary>
        /// <param name="conteudoArquivo">Conteúdo para analisar</param>
        /// <returns>True caso seja válido. False para arquivo inválido</returns>
        private bool ValidarArquivo(List<int> conteudoArquivo)
        {
            Validador validador = new Validador();
            string erro = validador.ValidarArquivoEntrada(conteudoArquivo);

            if (!string.IsNullOrEmpty(erro))
                Console.WriteLine(erro);

            return string.IsNullOrEmpty(erro);
        }


        /// <summary>
        /// Escrever em um arquivo.
        /// </summary>
        /// <param name="caminhoSalvarArquivo">Caminho absoluto onde será salvo</param>
        /// <param name="valoresParaEscrita">Lista contendo o que deverá ser escrito em cada linha</param>
        public void EscreverArquivo(string caminhoSalvarArquivo = null, List<string> valoresParaEscrita = null)
        {
            caminhoSalvarArquivo = string.IsNullOrEmpty(caminhoSalvarArquivo) ? DiretorioGravar : caminhoSalvarArquivo;
            if (valoresParaEscrita == null || valoresParaEscrita.Count == 0)
            {
                Console.WriteLine("Não há conteúdo para gravar, arquivo vazio ou inexistente");
                return;
            }

            string nomeArquivoExportar = DefinirNomeArquivo(caminhoSalvarArquivo);

            using (StreamWriter sw = new StreamWriter(nomeArquivoExportar))
            {

                try
                {
                    foreach (string item in valoresParaEscrita)
                        sw.WriteLine(item.Trim());

                    Console.WriteLine($"\nArquivo gravado com suceso. Diretório: \n{nomeArquivoExportar}");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"\nErro ao gravar o arquivo. MOTIVO: {ex.Message}");
                }
            }
        }


        /// <summary>
        /// Verificar se já exite um arquivo com o mesmo nome.
        /// </summary>
        /// <param name="caminhoArquivo">Caminho absoluto onde o arquivo será salvo.</param>
        /// <returns>Valor entre parênteses para o novo arquivo. Ex: (1) (2) (3)</returns>
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


        /// <summary>
        /// Verificar se o diretório raiz para leitura/escrita já existe.
        /// </summary>
        /// <param name="caminhoArquivo">Caminho absoluto.</param>
        public void VerificarDiretorioRaiz(string caminhoArquivo = null)
        {
            string dirRaizLeitura = this.DiretorioRaiz;
            string dirRaizEscrita = dirRaizLeitura + @"\Gravar";

            dirRaizLeitura += @"\Ler";


            if (!Directory.Exists(dirRaizLeitura) || caminhoArquivo == DiretorioLeitura)
                Directory.CreateDirectory(dirRaizLeitura);

            if (!Directory.Exists(dirRaizEscrita))
                Directory.CreateDirectory(dirRaizEscrita);

            dirRaizLeitura += @"\input.txt";
            if (!File.Exists(dirRaizLeitura))
                EscreverArquivo(dirRaizLeitura, GetArquivoPadrao());
        }


        /// <summary>
        /// Obter um arquivo padrão;
        /// </summary>
        /// <returns>Lista de strings contendo um arquivo padrão válido.</returns>
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
