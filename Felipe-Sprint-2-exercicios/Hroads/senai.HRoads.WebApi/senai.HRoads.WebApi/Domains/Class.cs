using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.HRoads.WebApi.Domains
{
    public partial class Class
    {
        public Class()
        {
            Personagens = new HashSet<Personagen>();
        }

        public int IdClasse { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Personagen> Personagens { get; set; }
    }
}
