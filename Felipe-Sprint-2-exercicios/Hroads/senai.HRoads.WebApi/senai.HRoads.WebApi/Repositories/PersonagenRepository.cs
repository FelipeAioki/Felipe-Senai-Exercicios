using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Senai.HRoads.WebApi.Contexts;
using Senai.HRoads.WebApi.Domains;
using SENAI_Hroads_API.Interfaces;

namespace SENAI_Hroads_API.Repositories
{
    /// <summary>
    /// Resposável pela classes dos Personagens
    /// </summary>
    public class PersonagenRepository : IPersonagenRepository
    {
        /// <summary>
        /// Objeto de contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HRoadsContext ctx = new HRoadsContext();


        /// <summary>
        /// Atualiza um Personagem existente
        /// </summary>
        /// <param name="id">id do persongem que será atualizado</param>
        /// <param name="PersonagenAtualizado">Objeto PersonagenAtualizado com as novas Informações</param>
        public void Atualizar(int id, Personagen PersonagenAtualizado)
        {
            //Busca um Personagem através do seu id
            Personagen PersonagemBuscado = ctx.Personagens.Find(id);
            
            //Verifica se o nome do Personagem foi informado
            if(PersonagenAtualizado.Nome != null)
            {
                //Atribui um valor ao campo existente
                PersonagemBuscado.Nome = PersonagenAtualizado.Nome;
            }

            //atualiza o campo buscado
            ctx.Personagens.Update(PersonagemBuscado);

            //salva as alterações para o banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Personagem através do seu id
        /// </summary>
        /// <param name="id">Id do personagem que será buscado</param>
        /// <returns> Um Personagem buscado</returns>
        public Personagen BuscarId(int id)
        {
            //Retorna uma lista com todas os Persoangens
            return ctx.Personagens.FirstOrDefault(p => p.IdPersonagem == id);
        }


        /// <summary>
        /// Cadastra um novo Personagem
        /// </summary>
        /// <param name="NovoPersonagem">Objeto NovoPersonagem que será cadastrado</param>
        public void Cadastrar(Personagen NovoPersonagem)
        {
            //Adiciona novo Personagem
            ctx.Personagens.Add(NovoPersonagem);

            //salva as informações para serem salvas no banco de dados
            ctx.SaveChanges();
        }


        /// <summary>
        /// Deleta um Personagem existente
        /// </summary>
        /// <param name="id">id do personagem que sera deletado</param>
        public void Deletar(int id)
        {
            //busca um Personagem através de seu id
            Personagen PersonagemBuscado = ctx.Personagens.Find(id);

            //remove o Personagem Buscado
            ctx.Personagens.Remove(PersonagemBuscado);

            //salvas as alterações no banco de dados
            ctx.SaveChanges();
        }


        /// <summary>
        /// Lista todos Personagens
        /// </summary>
        /// <returns>Lista de Personagens</returns>
        public List<Personagen> Listar()
        {
            //Retorna uma lista com todas os Personagens
            return ctx.Personagens.ToList();
        }


        /// <summary>
        /// Listar todas as classes com seus personagens
        /// </summary>
        /// <returns>Retorna uma lista de personagens com suas classes</returns>
        public List<Personagen> ListarPersonagen()
        {
            //retorna uma lista de Personagens com suas Classes
            return ctx.Personagens.Include(p => p.Classes).ToList();
        }
    }
}
