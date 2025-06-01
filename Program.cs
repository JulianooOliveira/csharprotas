// Juliano - 37593081
// Abgail - 8838616971
// Kevin - 8837169360

using ApiPaciente.Models;
using ApiMedico.Models;
using ApiEspecialidade.Models;
using Context.Modelo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura o banco SQLite
builder.Services.AddDbContext<SistemaSaudeContext>(options =>
    options.UseSqlite("Data Source=sistemasaude.db"));

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
    var context = scope.ServiceProvider.GetRequiredService<SistemaSaudeContext>();

    context.Database.Migrate();

    if (!context.Pacientes.Any())
    {
        var pacientesIniciais = new List<Paciente>
        {
            new()
            {
                NomeCompleto = "Maria da Silva",
                Nascimento = "1990-05-12",
                DocumentoCPF = "12345678900",
                Email = "maria.silva@gmail.com",
                Telefone = "44999990000",
                Endereco = "Rua das Flores, 123"
            },
            new()
            {
                NomeCompleto = "João da Silva",
                Nascimento = "1985-08-22",
                DocumentoCPF = "98765432100",
                Email = "joao.silva@gmail.com",
                Telefone = "44988887777",
                Endereco = "Av. Brasil, 456"
            }
        };

        context.Pacientes.AddRange(pacientesIniciais);
    }

    if (!context.Medicos.Any())
    {
        var medicosIniciais = new List<Medico>
        {
            new()
            {
                NomeMedico = "Dra. Ana Beatriz",
                CrmMedico = 12345,
                DataNascimentoMedico = new DateTime(1978, 6, 20),
                EspecialidadePrincipal = "Psiquiatria",
                CRMUf = "PR",
                TelefoneProfissional = "44999887766"
            },
            new()
            {
                NomeMedico = "Dr. Rafael Torres",
                CrmMedico = 67890,
                DataNascimentoMedico = new DateTime(1982, 2, 14),
                EspecialidadePrincipal = "Clínico Geral",
                CRMUf = "PR",
                TelefoneProfissional = "44999776655"
            }
        };

        context.Medicos.AddRange(medicosIniciais);
        context.SaveChanges(); // Salva os médicos primeiro para garantir os IDs
    }

    if (!context.Especialidades.Any())
    {
        var medico1 = context.Medicos.FirstOrDefault(m => m.NomeMedico == "Dra. Ana Beatriz");
        var medico2 = context.Medicos.FirstOrDefault(m => m.NomeMedico == "Dr. Rafael Torres");

        var especialidadesIniciais = new List<Especialidade>
        {
            new()
            {
                NomeEspecialidade = "Saúde Mental Comunitária",
                Descricao = "Promoção de saúde mental em comunidades vulneráveis.",
                NivelComplexidade = 3,
                IdMedico = medico1?.Id ?? 1
            },
            new()
            {
                NomeEspecialidade = "Atenção Primária Integral",
                Descricao = "Atendimento geral com enfoque em prevenção.",
                NivelComplexidade = 2,
                IdMedico = medico2?.Id ?? 2
            }
        };

        context.Especialidades.AddRange(especialidadesIniciais);
    }

    context.SaveChanges();
}

