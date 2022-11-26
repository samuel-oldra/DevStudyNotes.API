<h1 align="center">
  DevStudyNotes - Jornada .NET Direto ao Ponto
</h1>
<p align="center">
  <a href="#tecnologias-e-práticas-utilizadas">Tecnologias e práticas utilizadas</a> •
  <a href="#funcionalidades">Funcionalidades</a> •
  <a href="#comandos">Comandos</a>
</p>

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

## Comandos

### Comandos básicos
```
dotnet new gitignore
dotnet new webapi -o DevStudyNotes.API
dotnet build
dotnet run
dotnet watch run
dotnet publish
```

### Tool Entity Framework Core (migrations)
```
dotnet tool install --global dotnet-ef
dotnet tool uninstall --global dotnet-ef
```

### Migrations
```
dotnet ef migrations add InitialMigration -o Persistence/Migrations
dotnet ef database update
```
