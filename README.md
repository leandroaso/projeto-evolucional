# projeto-evolucional back

O projeto está utilizando Angular 10 no front com primeng, e o back está em .Net core 3.1 com Dapper usuando o FluentMigrator rodar as migrações e criar as tabelas.

Para rodar o front é necessário instalar o angular na versão 10.

Para rodar o back é necessário alterar a ConnectionStrings no arquivo 'appsettings.json' e marcar o projeto 'WebApplication' como Startup project se estiver rodando através do visual studio.
