using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class funcionariosDomain
    {
        public int idNome { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string nascimento { get; set; }
    }
}
