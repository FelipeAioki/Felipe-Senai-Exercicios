using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.HRoads.WebApi.Domains
{
    public partial class Personagen
    {
        
        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }
        public string Nome { get; set; }
        public int? MaxVida { get; set; }
        public int? MaxMana { get; set; }
        public string Atualizacao { get; set; }
        public DateTime? Criacao { get; set; }

        public virtual Classes IdClasseNavigation { get; set; }

        //public object Classes { get;  set; }

        public virtual ICollection<Classes> Classes { internal get; set; }
    }
}
