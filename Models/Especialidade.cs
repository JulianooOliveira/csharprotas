using System;
using ApiMedico.Models;

namespace ApiEspecialidade.Models
{
    public class Especialidade
    {
        public int Id { get; set; }
        public required string NomeEspecialidade { get; set; }
        public required string Descricao { get; set; }

        public int? IdMedico { get; set; }

        public Medico? Medico { get; set; }

        public int NivelComplexidade { get; set; }
    }

}
