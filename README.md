# Balanceador de Carga para ambientes Cloud

## Passo-a-passo para executar o aplicativo:
1. Possuir o .NET Core 3.1 **SDK** ou superior instalado. [.NET Core SDK Download](https://dotnet.microsoft.com/download/dotnet/3.1).
   - [Download .NET Core SDK para Windows](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-3.1.411-windows-x64-installer).
2. Realizar o download do arquivo "BalanceadorCargaCloud.rar" localizado na sessão de releases do repositório atual. [Releases](https://github.com/lucas-amstalden/Balanceador-de-Carga/releases).
   - Obs: Talvez seja necessário desabilitar o Windows Defender. [Desabilitar Proteção em tempo real](https://support.microsoft.com/pt-br/windows/desativar-a-prote%C3%A7%C3%A3o-antiv%C3%ADrus-defender-na-seguran%C3%A7a-do-windows-99e6004f-c54c-8509-773c-a4d776b77960#:~:text=Selecione%20Iniciar%20%3E%20Configura%C3%A7%C3%B5es%20%3E%20Atualiza%C3%A7%C3%A3o%20e,vers%C3%B5es%20anteriores%20do%20Windows%2010).
4. Após o download, descompactar o arquivo no diretório preferido. [Ferramentas gratuitas para descompactar](https://pplware.sapo.pt/software/5-ferramentas-gratuitas-para-descompactar-ficheiros-rar/).
5. Após descompactar, abrir a pasta "BalanceadorCargaCloud" e executar o arquivo "Balanceador-de-Carga.exe".


- Após isso o programa iniciará o prompt de comando no diretório em que o executável está alocado e pedirá para informar o caminho **absoluto** do arquivo input.txt.
  - Obs: Caso não informar nenhum caminho então o programa irá criar um arquivo padrão válido o seguinte caminho:
    - "Diretório raiz do aplicativo/Arquivos/Ler/input.txt".
- Por fim, após o processamento do arquivo válido o aplicativo irá salvar o arquivo output.txt no diretório à seguir:
    - "Diretório raiz do aplicativo/Arquivos/Gravar/output.txt".

## Passo-a-passo para executar a bateria de testes unitários:
1. Possuir o Visual Studio instalado no computador. [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/).
2. Baixar o código fonte disponibilizado no repositório. [Código Fonte do Projeto](https://github.com/lucas-amstalden/Balanceador-de-Carga.git).
3. Acessar o menu 'View > Test Explorer' e escolher a opção 'Run All Tests in View'. 
- Vídeo explicativo executando os testes unitário. [Link para o vídeo](https://youtu.be/mVlw7lcsDio).
