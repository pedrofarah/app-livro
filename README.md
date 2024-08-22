#Pedro Farah (14) 99103.0770

Sistema desenvolvido utilizando o framework **.NET 8** e **Visual Studio 2022** e ** Angular 18 **

Banco de dados **EF Core In-Memory Database**

** Projeto API **

- livro.api.persistence -

Responsável pela persistência dos dados. 
Utilizando o padrões Unit of Work e Repository.

- livro.api.domain -

Responsável pela validação das regras de negócio.

- livro.api.host -

Projeto principal, responsável pela execução da api.

** Passos para executar o projeto da API **

1 - Vá até o diretório app-livro\livro.api

- Via Visual Studio

1 - Abra a solution livro.api.sln

2 - Selecione o projeto livro.api.host como projeto de inicialização

3 - Execute o projeto.

- Via DotNet CLI

1 - Vá até o diretório \livro.api.host

2 - Execute o comando dotnet run.

*** Por padrão a API inciará nas portas 5000 (http) ou 5001 (https).

Utilize a gui do Swagger para visualizar os endpoints: /swagger

** Projeto Front-end **

Desenvolvido com a versão do Angular 18.2.0

** Passos para executar o projeto do Front-end **

1 - Vá até o diretório livro.client

2 - Digite "npm install" para instalar os pacotes do node.

3 - Digite ng serve para iniciar o projeto.


Obrigado!