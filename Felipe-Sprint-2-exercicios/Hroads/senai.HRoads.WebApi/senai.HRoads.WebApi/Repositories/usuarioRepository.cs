using Senai.HRoads.WebApi.Contexts;
using Senai.HRoads.WebApi.Domains;
using Senai.HRoads.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.HRoads.WebApi.Repositories
{
    public class usuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source =DESKTOP-5SR3EMT; initial catalog=Senai_Hroads_Manha; user id=sa; pwd=6228";

        HRoadsContext ctx = new HRoadsContext();

        public Usuario buscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //string querrySelectAll = "SELECT IdUsuario, TU.IdTipoUsuario ,Email, Senha, Titulo AS Permissao FROM Usuario U INNER JOIN TipoUsuario TU ON u.IdTipoUsuario = TU.IdTipoUsuario WHERE Email = @email AND Senha = @senha";
                string querrySelectAll = "SELECT IdUsuario, IdTipoUsuario ,Email, Senha FROM Usuario WHERE Email = @email AND Senha = @senha";
                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TipoUsuario usuariobuscado1 = new TipoUsuario();
                        Usuario usuariobuscado = new Usuario
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            IdTipoUsuario = Convert.ToInt32(rdr[1]),
                            Email = rdr[2].ToString(),
                            Senha = rdr[3].ToString(),
                            //Permissao = rdr[4].ToString(),
                        };
                        return usuariobuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            //Adiciona um novo usuario
            ctx.Usuarios.Add(novoUsuario);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
