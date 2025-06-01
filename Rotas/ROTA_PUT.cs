using ApiEspecialidade.Models;
using ApiMedico.Models;
using ApiPaciente.Models;
using Context.Modelo;
using Microsoft.EntityFrameworkCore;

public static class ROTA_PUT
{
    public static void MapPutRoutes(this WebApplication app)
    {
        // Atualizar Paciente
        app.MapPut("/api/pacientes/{id}", async (int id, Paciente pacienteAtualizado, SistemaSaudeContext db) =>
        {
            var paciente = await db.Pacientes.FindAsync(id);
            if (paciente == null)
                return Results.NotFound("Paciente não encontrado.");

            paciente.NomeCompleto = pacienteAtualizado.NomeCompleto;
            paciente.Nascimento = pacienteAtualizado.Nascimento;
            paciente.DocumentoCPF = pacienteAtualizado.DocumentoCPF;
            paciente.Email = pacienteAtualizado.Email;
            paciente.Telefone = pacienteAtualizado.Telefone;
            paciente.Endereco = pacienteAtualizado.Endereco;

            await db.SaveChangesAsync();
            return Results.Ok(paciente);
        });

        // Atualizar Medico
        app.MapPut("/api/medicos/{id}", async (int id, Medico medicoAtualizado, SistemaSaudeContext db) =>
        {
            var medico = await db.Medicos.FindAsync(id);
            if (medico == null)
                return Results.NotFound("Médico não encontrado.");

            medico.NomeMedico = medicoAtualizado.NomeMedico;
            medico.CrmMedico = medicoAtualizado.CrmMedico;
            medico.DataNascimentoMedico = medicoAtualizado.DataNascimentoMedico;
            medico.EspecialidadePrincipal = medicoAtualizado.EspecialidadePrincipal;
            medico.CRMUf = medicoAtualizado.CRMUf;
            medico.TelefoneProfissional = medicoAtualizado.TelefoneProfissional;

            await db.SaveChangesAsync();
            return Results.Ok(medico);
        });

        // Atualizar Especialidade
        app.MapPut("/api/especialidades/{id}", async (int id, Especialidade especialidadeAtualizada, SistemaSaudeContext db) =>
        {
            var especialidade = await db.Especialidades.FindAsync(id);
            if (especialidade == null)
                return Results.NotFound("Especialidade não encontrada.");

            especialidade.NomeEspecialidade = especialidadeAtualizada.NomeEspecialidade;
            especialidade.Descricao = especialidadeAtualizada.Descricao;
            especialidade.IdMedico = especialidadeAtualizada.IdMedico;
            especialidade.NivelComplexidade = especialidadeAtualizada.NivelComplexidade;

            await db.SaveChangesAsync();
            return Results.Ok(especialidade);
        });
    }
}
