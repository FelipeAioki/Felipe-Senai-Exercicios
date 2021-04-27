using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.HRoads.WebApi.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
