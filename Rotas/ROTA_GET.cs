using Microsoft.EntityFrameworkCore;
using models;

namespace Rotas
{
    public static class Rota_GET
    {
        public static void MapGetRoutes(this WebApplication app)
        {
            app.MapGet("/paciente", async (Paciente context) =>
            {
                var paciente = await context.pacientes.ToListAsync();
                return Results.Ok(paciente);
            });

            app.MapGet("/paciente/{id}", async (int id, PacienteContext context) =>
            {
                var livro = await context.pacientes.FindAsync(id);
                return livro is not null ? Results.Ok(livro) : Results.NotFound();
            });
        }
    }
}