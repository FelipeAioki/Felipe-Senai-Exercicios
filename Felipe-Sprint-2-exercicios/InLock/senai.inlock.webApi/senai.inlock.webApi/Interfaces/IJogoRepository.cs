using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Método para listar todos os jogos
        /// </summary>
        /// <returns></returns>
        List<jogoDomain> ListarTodos();


        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        /// 
        //void Cadastrar(jogoDomain novoJogo);
    }
}
