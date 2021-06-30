using System;
using System.Collections.Generic;

#nullable disable

namespace Sp_Medical_Group.Domains
{
    public partial class Clínica
    {
        public int IdClinica { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Endereço { get; set; }
        public string Horarios { get; set; }
    }
}
