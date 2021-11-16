# projeto-evolucional back

O projeto foi feito com o front e o back separados o front está utilizando Angular 10 com primeng, e o back está em .Net core 3.1 WebApi com Dapper, Sql Server e FluentMigrator para rodar as migrações e criar as tabelas.


**Requisitos para rodar o front.**

Ter o `Node` instalado de preferência na (versão) 10.16.3 que foi a que utilizei.
Também é necessário o Angular CLI na (versão) 10 instalado. Comanda para instalação: `npm install @angular/cli@10 -g --save`.

Depois disso é só instalar as dependências do projeto com o comando: `npm install` na pasta rais do projeto front, por fim o para subir o projeto o comando é `ng s` ou `npx ng s`. 


**Requisitos para rodar o back.**

Sera necessário alterar a conexão do banco de dados que está no arquivo `appsettings.json` dentro do projeto `WebApplication`,  substituir o valor da TAG `SqlServer` por uma conexão do Sql Server.

Se for rodar pelo visual studio é preciso marcar o projeto `WebApplication` como Startup project.
