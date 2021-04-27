using System;
using System.Collections.Generic;
using System.Security.Claims;

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
        public ClaimsIdentity Permissao { get; internal set; }
    }
}
