using ApiEspecialidade.Models;
using ApiMedico.Models;
using ApiPaciente.Models;
using Context.Modelo;

public static class ROTA_POST
{
    public static void MapPostRoutes(this WebApplication app)
    {
        // Criar novo paciente
        app.MapPost("/api/pacientes", async (Paciente novoPaciente, SistemaSaudeContext db) =>
        {
            db.Pacientes.Add(novoPaciente);
            await db.SaveChangesAsync();
            return Results.Created($"/api/pacientes/{novoPaciente.Id}", novoPaciente);
        });

        // Criar novo médico
        app.MapPost("/api/medicos", async (Medico novoMedico, SistemaSaudeContext db) =>
        {
            db.Medicos.Add(novoMedico);
            await db.SaveChangesAsync();
            return Results.Created($"/api/medicos/{novoMedico.Id}", novoMedico);
        });

        // Criar nova especialidade
        app.MapPost("/api/especialidades", async (Especialidade novaEspecialidade, SistemaSaudeContext db) =>
        {
            db.Especialidades.Add(novaEspecialidade);
            await db.SaveChangesAsync();
            return Results.Created($"/api/especialidades/{novaEspecialidade.Id}", novaEspecialidade);
        });
    }
}
