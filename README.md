# Projeto de API usando C# e .NET 6

## DevStudyNotes - Jornada .NET Direto ao Ponto

Foi desenvolvida uma API REST completa de cadastro e leitura de notas de estudo.

## Tecnologias e práticas utilizadas
- ASP.NET Core com .NET 7
- Entity Framework Core
- SQLite / In-Memory database
- Swagger
- Injeção de Dependência
- Programação Orientada a Objetos
- Logs com Serilog
- Clean Code
- Publicação

## Funcionalidades
- Cadastro, Listagem, Detalhes de Notas de Estudo
- Cadastro de Reações

###

![alt text](https://raw.githubusercontent.com/samuel-oldra/DevStudyNotes.API/main/README_IMGS/swagger_ui.png)

## Comandos básicos
```
dotnet new gitignore
dotnet new webapi -o DevGames.API
dotnet build
dotnet run
dotnet watch run
dotnet test
dotnet publish
```

## Tool Entity Framework Core (migrations)
```
dotnet tool install --global dotnet-ef
```

## Migrations
```
dotnet ef migrations add InitialMigration -o Persistence/Migrations
dotnet ef database update
```