# Balanceador de Carga para ambientes Cloud

## Passo-a-passo para executar o aplicativo:
1. Possuir o .NET Core 3.1 **SDK** ou superior instalado. [.NET Core SDK Download](https://dotnet.microsoft.com/download/dotnet/3.1).
   - [Download .NET Core SDK para Windows](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-3.1.411-windows-x64-installer).
2. Realizar o download do arquivo "BalanceadorCargaCloud.rar" localizado na sessão de releases do repositório atual. [Releases](https://github.com/lucas-amstalden/Balanceador-de-Carga/releases).
3. Após o download, descompactar o arquivo no diretório preferido. [Ferramentas gratuitas para descompactar arquivos](https://pplware.sapo.pt/software/5-ferramentas-gratuitas-para-descompactar-ficheiros-rar/).
4. Após descompactar, abrir a pasta "BalanceadorCargaCloud" e executar o arquivo "Balanceador-de-Carga.exe".

- Após isso o programa iniciará o prompt de comando no diretório em que o executável está alocado e pedirá para informar o caminho **absoluto** do arquivo input.txt.
  - Obs: Caso não informar nenhum caminho então o programa irá criar um arquivo padrão válido o seguinte caminho:
    - "Diretório raiz do aplicativo/Arquivos/Ler/input.txt".
- Por fim, após o processamento do arquivo válido o aplicativo irá salvar o arquivo output.txt no diretório à seguir:
    - "Diretório raiz do aplicativo/Arquivos/Gravar/output.txt".
