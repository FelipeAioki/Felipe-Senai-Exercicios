using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class jogoDomain
    {
        public int idJogo { get; set; }
        public int idEstudio { get; set; }
        public string nome { get; set; }
        public string estudio { get; set; }
        public string descrição { get; set; }
        public DateTime lancamento { get; set; }
        public Decimal valor { get; set; }
    }
}
