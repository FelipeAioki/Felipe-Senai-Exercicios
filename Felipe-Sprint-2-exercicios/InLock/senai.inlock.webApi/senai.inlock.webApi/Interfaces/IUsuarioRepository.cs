using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IUsuarioRepository
    {
         
        /// <summary>
        /// Retorna uma lista dos estudios
        /// </summary>
        /// <returns></returns>
        List<usuarioDomain> Listar();

        /// <summary>
        /// Cria um novo estudo
        /// </summary>
        /// <param name="novoEstudio"></param>
        void Cadastrar(usuarioDomain novoUsuario);

        public usuarioDomain buscarPorEmailSenha(string email, string senha);

    }
}
