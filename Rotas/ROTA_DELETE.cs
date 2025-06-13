using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Context.Modelo;
using ApiEspecialidade.Models;

public static class Rota_DELETE
{
    public static void MapDeleteRoutes(this WebApplication app)
    {
        // Deletar paciente por ID
        app.MapDelete("/api/pacientes/{id}", async (int id, SistemaSaudeContext context) =>
        {
            var paciente = await context.Pacientes.FindAsync(id);
            if (paciente is null) return Results.NotFound("Paciente não encontrado.");

            context.Pacientes.Remove(paciente);
            await context.SaveChangesAsync();
            return Results.Ok("Paciente removido com sucesso.");
        });

        app.MapDelete("/api/medicos/{id}", async (int id, SistemaSaudeContext context) =>
{
    try
    {
        var medico = await context.Medicos
            .Include(m => m.Especialidades)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (medico is null)
            return Results.NotFound("Médico não encontrado.");

        foreach (var especialidade in medico.Especialidades ?? new List<Especialidade>())
        {
            especialidade.IdMedico = null;
        }

        context.Medicos.Remove(medico);
        await context.SaveChangesAsync();
        return Results.Ok("Médico removido com sucesso, especialidades desvinculadas.");
    }
    catch (Exception ex)
    {
        return Results.Problem($"Erro interno: {ex.Message}");
    }
});


        // Deletar especialidade por ID
        app.MapDelete("/api/especialidades/{id}", async (int id, SistemaSaudeContext context) =>
        {
            var especialidade = await context.Especialidades.FindAsync(id);
            if (especialidade is null) return Results.NotFound("Especialidade não encontrada.");

            context.Especialidades.Remove(especialidade);
            await context.SaveChangesAsync();
            return Results.Ok("Especialidade removida com sucesso.");
        });
    }
}
