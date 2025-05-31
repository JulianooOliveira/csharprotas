using models;

public static class Rota_DELETE
{
    public static void MapDeleteRoutes(this WebApplication app)
    {
        app.MapDelete("/paciente/{id}", async (int id, PacienteContext context) =>
        {
            var livro = await context.pacientes.FindAsync(id);
            if (livro is null) return Results.NotFound();

            context.pacientes.Remove(livro);
            await context.SaveChangesAsync();
            return Results.Ok();
        });
    }
}