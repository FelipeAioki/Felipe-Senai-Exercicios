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
    /// Reponsável pelos repositórios das Classes
    /// </summary>
    public class ClassesRepository : IClassesRepository
    {
        /// <summary>
        /// Objeto de contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();


        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">id da classe que será atualizada</param>
        /// <param name="ClasseAtualizada">Objeto ClasseAtualizada com as novas Informações</param>
        public void Atualizar(int id, Classes ClasseAtualizada)
        {
            //busca uma classe através do Id
            Classes ClasseBuscada = ctx.Classes.Find(id);

            //verifica se o nome da classe foi informada
            if (ClasseAtualizada.Nome != null)
            {
                //atribui o valor ao campo existente    
                ClasseBuscada.Nome = ClasseAtualizada.Nome;
            }

            //atualiza o campo buscado
            ctx.Classes.Update(ClasseBuscada);

            //salva as alterações para serem salvas no banco de dados
            ctx.SaveChanges();
        }


        /// <summary>
        /// Busca sua classe através do seu id
        /// </summary>
        /// <param name="id">Id classe será busacado</param>
        /// <returns> Uma classe buscada</returns>
        public Classes BuscarId(int id)
        {
            //Retorna uma lista com todas as classes
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        public void Cadastrar(Classes NovaClasse)
        {
            //Adiciona nova Classe
            ctx.Classes.Add(NovaClasse);

            //salva as informações para serem salvas no banco de dados
            ctx.SaveChanges();
        }


        /// Deleta uma Classe existente
        /// </summary>
        /// <param name="id">id da classe que sera deletada</param>
        public void Deletar(int id)
        {
            //busca uma classe através de seu id
            Classes classesBuscada = ctx.Classes.Find(id);

            //remove a classe buscada
            ctx.Classes.Remove(classesBuscada);

            //salvas as alterações no banco de dados
            ctx.SaveChanges();
        }


        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Lista de classes</returns>
        public List<Classes> Listar()
        { 
            //Retorna uma lista com todas as classes
            return ctx.Classes.ToList();
        }


        /// <summary>
        /// Listar todas as classes com seus personagens
        /// </summary>
        /// <returns>Retorna uma lista de classes com seus personagens</returns>
        public List<Classes> ListarClasses()
        {
            //retorna uma lista de classes e seus personagens
            return ctx.Classes.Include(c => c.Personagens).ToList();
        }
    }
}
