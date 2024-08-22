#Pedro Farah (14) 99103.0770

Sistema desenvolvido utilizando o framework **.NET 8** e **Visual Studio 2022**

Banco de dados **EF Core In-Memory Database**

** Projeto API **



** Passos para executar o projeto da API **

1 - Abra 

1 - Abra a solution PedroFarah.Web.Api

2 - Selecione o projeto PedroFarah.Web.Api.Host como projeto de inicialização

3 - Execute o projeto

Utilize a gui do Swagger para visualizar os endpoints: /swagger

Passos para operar o sistema:

1 - Inicialmente foram adicionados dois usuários via seed do Ef Core. São eles:

{
  "email": "usuario1@apitarefas.net",
  "senha": "usr@1"
}

{
  "email": "usuario2@apitarefas.net",
  "senha": "usr@2"
}

2 - Execute o endpoint /Login passando um dos usuários acima como parâmetro para que seja retornado o token JWT.

3 - Utilize o token retornado no passo anterior para realizar a autenticação. Campo "Authorization token" na tela de autenticação do swagger (Botão Authorize). 

4 - Realizando a autenticação, os endpoints /tarefa e /usuario estarão liberados.

Obs: Não há necessidade de informar o Id do usuário nos payloads dos endpoints /tarefa. Esta informação é passada internamente via token JWT.

Obrigado!