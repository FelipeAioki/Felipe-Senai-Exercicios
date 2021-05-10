using System;
using System.Collections.Generic;

#nullable disable

namespace Sp_Medical_Group.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdEspecialidade { get; set; }
        public string Nome { get; set; }

        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
