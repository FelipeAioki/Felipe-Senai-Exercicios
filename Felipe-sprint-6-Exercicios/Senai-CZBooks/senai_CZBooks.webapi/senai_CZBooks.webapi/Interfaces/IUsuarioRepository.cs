using senai_CZBooks.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks.webapi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario buscarPorEmailSenha(string email, string senha);
    }
}
