using System;
using Senai.HRoads.WebApi.Domains;
using System.Collections.Generic;

#nullable disable

namespace Senai.HRoads.WebApi.Domains
{
    public partial class Classes
    {
        public Classes()
        {
            Personagens = new HashSet<Personagen>();
        }

        public int IdClasse { get; set; }
        public string Nome { get; set; }
        //public virtual Personagen IdPersonagenNavigation { get; set; }
        public virtual ICollection<Personagen> Personagens { internal get; set; }
    }
}
