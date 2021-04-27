using Senai.HRoads.WebApi.Contexts;
using Senai.HRoads.WebApi.Domains;
using Senai.HRoads.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.HRoads.WebApi.Repositories
{
    public class tipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HRoadsContext ctx = new HRoadsContext();

        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            //Adiciona um novo usuario
            ctx.TipoHabilidades.Add(novoTipoHabilidade);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        public List<TipoHabilidade> Listar()
        {
            return ctx.TipoHabilidades.ToList();
        }
    }
}
