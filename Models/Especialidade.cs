using System;

namespace ApiEspecialidade.Models
{
    public class Especialidade
    {
        public int Id { get; set; }

        public required string NomeEspecialidade { get; set; }

        public required string Descricao { get; set; }

        public int IdMedico { get; set; }

        public int NivelComplexidade { get; set; }
    }
}
