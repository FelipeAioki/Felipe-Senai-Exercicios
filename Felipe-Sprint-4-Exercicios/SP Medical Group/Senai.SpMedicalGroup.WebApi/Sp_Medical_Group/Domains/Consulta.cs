using System;
using System.Collections.Generic;

#nullable disable

namespace Sp_Medical_Group.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public int? IdMedico { get; set; }

        public string Especialidade { get; set; }
        public string Medico { get; set; }
        public int? IdPaciente { get; set; }
        public DateTime DataDaConsulta { get; set; }
        public string Situação { get; set; }
        public string Endereço { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
