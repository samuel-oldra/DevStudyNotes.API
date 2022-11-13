using DevStudyNotes.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DevStudyNotes");

// Para publicar, descomente as três linhas abaixo, e comente as outras 3 linhas que configuram o EF Core para usar o SQL Server
// builder.Services.AddDbContext<StudyNoteDbContext>(
//     o => o.UseInMemoryDatabase("DevStudyNotesDb")
// );

builder.Services.AddDbContext<StudyNoteDbContext>(
    o => o.UseSqlServer(connectionString)
);

// Para publicar, descomente as linhas abaixo relativas a configuração do Serilog
builder.Host.ConfigureAppConfiguration((hostingContext, config) => {
    Serilog.Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.MSSqlServer(connectionString,
            sinkOptions: new MSSqlServerSinkOptions() {
                AutoCreateSqlTable = true,
                TableName = "Logs"
            })
        .WriteTo.Console()
        .CreateLogger();
}).UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "DevStudyNotes.API",
        Version = "v1",
        Contact = new OpenApiContact {
            Name = "LuisDev",
            Email = "contato@ld.com.br",
            Url = new Uri("https://luisdev.com.br")
        }
    });

    var xmlFile = "DevStudyNotes.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
