using System;
using System.Collections.Generic;

#nullable disable

namespace Sp_Medical_Group.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Pacientes = new HashSet<Paciente>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string NomeTipo { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
