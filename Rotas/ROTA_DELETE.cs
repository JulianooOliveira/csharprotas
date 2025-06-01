using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Context.Modelo;

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

        // Deletar médico por ID
        app.MapDelete("/api/medicos/{id}", async (int id, SistemaSaudeContext context) =>
        {
            var medico = await context.Medicos.FindAsync(id);
            if (medico is null) return Results.NotFound("Médico não encontrado.");

            context.Medicos.Remove(medico);
            await context.SaveChangesAsync();
            return Results.Ok("Médico removido com sucesso.");
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
