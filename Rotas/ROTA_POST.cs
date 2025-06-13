using ApiEspecialidade.Models;
using ApiMedico.Models;
using ApiPaciente.Models;
using Context.Modelo;
using Microsoft.EntityFrameworkCore;

public static class ROTA_POST
{
    public static void MapPostRoutes(this WebApplication app)
    {
        // Criar novo paciente
        app.MapPost("/api/pacientes", async (Paciente novoPaciente, SistemaSaudeContext db) =>
{
    var medicoExiste = await db.Medicos.AnyAsync(m => m.Id == novoPaciente.IdMedico);
    var especialidadeExiste = await db.Especialidades.AnyAsync(e => e.Id == novoPaciente.IdEspecialidade);

    if (!medicoExiste || !especialidadeExiste)
        return Results.BadRequest("Médico ou Especialidade inválida.");

    db.Pacientes.Add(novoPaciente);
    await db.SaveChangesAsync();
    return Results.Created($"/api/pacientes/{novoPaciente.Id}", novoPaciente);
});

        // Criar novo médico
        app.MapPost("/api/medicos", async (Medico novoMedico, SistemaSaudeContext db) =>
{
    try
    {
        db.Medicos.Add(novoMedico);
        await db.SaveChangesAsync();
        return Results.Created($"/api/medicos/{novoMedico.Id}", novoMedico);
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Erro: {ex.Message}");
    }
});

        // Criar nova especialidade
        app.MapPost("/api/especialidades", async (Especialidade novaEspecialidade, SistemaSaudeContext db) =>
{
    if (novaEspecialidade.IdMedico != null && !await db.Medicos.AnyAsync(m => m.Id == novaEspecialidade.IdMedico))
        return Results.BadRequest("Médico não encontrado.");

    db.Especialidades.Add(novaEspecialidade);
    await db.SaveChangesAsync();
    return Results.Created($"/api/especialidades/{novaEspecialidade.Id}", novaEspecialidade);
});


    }
}
