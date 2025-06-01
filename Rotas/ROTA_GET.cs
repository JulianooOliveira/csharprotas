using Microsoft.EntityFrameworkCore;
using Context.Modelo;

public static class ROTA_GET
{
    public static void MapGetRoutes(this WebApplication app)
    {
        // Mensagem de status simples da API
        app.MapGet("/", () => "API de cadastro médico funcionando perfeitamente! 🩺");

        // --- PACIENTES ---
        app.MapGet("/api/pacientes", async (SistemaSaudeContext db) =>
            await db.Pacientes.ToListAsync());

        app.MapGet("/api/pacientes/{id}", async (int id, SistemaSaudeContext db) =>
        {
            var paciente = await db.Pacientes.FindAsync(id);
            return paciente != null
                ? Results.Ok(paciente)
                : Results.NotFound("Paciente não encontrado.");
        });

        // --- MEDICOS ---
        app.MapGet("/api/medicos", async (SistemaSaudeContext db) =>
            await db.Medicos.ToListAsync());

        app.MapGet("/api/medicos/{id}", async (int id, SistemaSaudeContext db) =>
        {
            var medico = await db.Medicos.FindAsync(id);
            return medico != null
                ? Results.Ok(medico)
                : Results.NotFound("Médico não encontrado.");
        });

        // --- ESPECIALIDADES ---
        app.MapGet("/api/especialidades", async (SistemaSaudeContext db) =>
            await db.Especialidades.ToListAsync());

        app.MapGet("/api/especialidades/{id}", async (int id, SistemaSaudeContext db) =>
        {
            var especialidade = await db.Especialidades.FindAsync(id);
            return especialidade != null
                ? Results.Ok(especialidade)
                : Results.NotFound("Especialidade não encontrada.");
        });
    }
}
