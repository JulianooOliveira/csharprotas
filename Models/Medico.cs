using System;

namespace ApiMedico.Models
{
    public class Medico
    {
        public int Id { get; set; }

        public required string NomeMedico { get; set; }

        public int CrmMedico { get; set; }

        public DateTime DataNascimentoMedico { get; set; }

        public required string EspecialidadePrincipal { get; set; }

        public required string CRMUf { get; set; }

        public required string TelefoneProfissional { get; set; }
    }
}
