using DevStudyNotes.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// PARA ACESSO AO BANCO EM MEMÓRIA
builder.Services.AddDbContext<StudyNoteDbContext>(o => o.UseInMemoryDatabase("DevStudyNotesDb"));

// PARA ACESSO AO SQL Server
// var connectionString = builder.Configuration.GetConnectionString("DevStudyNotes");
// builder.Services.AddDbContext<StudyNoteDbContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DevStudyNotes.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Samuel B. Oldra",
            Email = "samuel.oldra@gmail.com",
            Url = new Uri("https://github.com/samuel-oldra")
        }
    });

    var xmlFile = "DevStudyNotes.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    o.IncludeXmlComments(xmlPath);
});

// Serilog
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    Serilog.Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()

        // PARA LOG NO SQL Server
        // .WriteTo.MSSqlServer(
        //     connectionString,
        //     sinkOptions: new MSSqlServerSinkOptions()
        //     {
        //         AutoCreateSqlTable = true,
        //         TableName = "Logs"
        //     })

        // PARA LOG NO CONSOLE
        .WriteTo.Console()

        .CreateLogger();
}).UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
// INFO: Swagger visível só em desenvolvimento
if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();