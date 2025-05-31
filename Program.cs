using Microsoft.EntityFrameworkCore;
using models;
using rotas;

var builder = WebApplication.CreateBuilder(args);

// Configura o banco SQLite
builder.Services.AddDbContext<PacienteContext>(options =>
    options.UseSqlite("Data Source=paciente.db"));

// Configura o CORS para permitir qualquer origem
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll");

// Mapeia as rotas REST
app.MapGetRoutes();
app.MapPostRoutes();
app.MapPutRoutes();
app.MapDeleteRoutes();

// Popular o banco com dados iniciais, se estiver vazio
PopularBancoDeDados(app);

// Inicia a aplicação
app.Run();

void PopularBancoDeDados(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<PacienteContext>();

    context.Database.Migrate();

    if (!context.pacientes.Any())
    {
        var livrosIniciais = new List<Paciente>
        {
            new() { Id = 1, Nome = "Referência 1", DataNascimento = "Autor 1", CPF = "2020"},
            new() { Id = 2, Nome = "Referência 1", DataNascimento = "Autor 1", CPF = "2020"},
           
            // Continue com até 20 referências reais se desejar
        };

        context.pacientes.AddRange(livrosIniciais);
        context.SaveChanges();
    }
}