using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.HRoads.WebApi.Domains
{
    public partial class ClassesHabilidade
    {
        public int? IdClasse { get; set; }
        public int? IdHab { get; set; }

        public virtual Classes IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabNavigation { get; set; }
    }
}
