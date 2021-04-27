using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.HRoads.WebApi.Domains
{
    public partial class Habilidade
    {
        public int IdHab { get; set; }
        public int? IdTipo { get; set; }
        public string Nome { get; set; }

        public virtual TipoHabilidade IdTipoNavigation { get; set; }
    }
}
