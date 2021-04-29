using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Senai.HRoads.WebApi.Contexts;
using Senai.HRoads.WebApi.Domains;
using Senai.HRoads.WebApi.Interfaces;

namespace Senai.HRoads.WebApi.Repositories
{
        /// <summary>
        /// Resposável pela classes dos Personagens
        /// </summary>
    public class HabilidadeRepository : IHabilidadeRepository
    {

        /// <summary>
        /// Objeto de contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();


        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">id da habilidade que será atualizada</param>
        /// <param name="HabilidadeAtualizada">Objeto HabilidadeAtualizada com as novas Informações</param>
        public void Atualizar(int id, Habilidade HabilidadeAtualizada)
        {
            //Busca uma Habiliade através do seu id
            Habilidade HabilidadeBuscada = ctx.Habilidades.Find(id);

            //Verifica se o nome da habilidade foi informada
            if (HabilidadeAtualizada.Nome != null)
            {
                //Atribui um valor ao campo existente
                HabilidadeBuscada.Nome = HabilidadeAtualizada.Nome;
            }

            //atualiza o campo buscado
            ctx.Habilidades.Update(HabilidadeBuscada);

            //salva as alterações para o banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca sua habilidade através do seu id
        /// </summary>
        /// <param name="id">Id habilidade será busacado</param>
        /// <returns> Uma habilidade buscada</returns>
        public Habilidade BuscarId(int id)
        {
            //Retorna uma lista com todas as Habilidades
            return ctx.Habilidades.FirstOrDefault(h => h.IdHab == id);
        }


        /// <summary>
        /// Cadastra uma nova Habilidade
        /// </summary>
        /// <param name="NovaHabiliade">Objeto NovaHabiliade que será cadastrada</param>
        public void Cadastrar(Habilidade NovaHabiliade)
        {
            //Adiciona uma nova Habilidade
            ctx.Habilidades.Add(NovaHabiliade);

            //salva as informações para serem salvas no banco de dados
            ctx.SaveChanges();
        }


        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">id da habilidade que sera deletada</param>
        public void Deletar(int id)
        {
            //busca uma habilidade através de seu id
            Habilidade HabilidadeBuscada = ctx.Habilidades.Find(id);

            //remove a habilidade Buscada
            ctx.Habilidades.Remove(HabilidadeBuscada);

            //salvas as alterações no banco de dados
            ctx.SaveChanges();
        }


        /// <summary>
        /// Lista todas as Habilidades
        /// </summary>
        /// <returns>Lista de habilidades</returns>
        public List<Habilidade> Listar()
        {
            //Retorna uma lista com todas as Habilidades
            return ctx.Habilidades.Include(h => h.IdTipoNavigation).ToList();
        }


        /// <summary>
        /// Listar todas as habilidades com seus personagens
        /// </summary>
        /// <returns>Retorna uma lista de habilidades com seus personagens</returns>
        public List<Habilidade> ListarHabilidades()
        {
            return ctx.Habilidades.Include(h => h.IdTipoNavigation).ToList();
        }
    }
}
