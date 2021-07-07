using Sp_Medical_Group.Contexts;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Repositories
{
    public class usuarioRepository : IUsuarioRepository
    {
        private string stringConexao = @"Data Source = LAB08DESK601\SQLEXPRESS; initial catalog = SP_Medical_Group; Integrated Security = true;";

        /// <summary>
        /// Objeto de contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        public void Atualizar(int id, Usuario UsuarioAtualizado)
        {
            //busca uma classe através do Id
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            //verifica se o nome da classe foi informada
            if (UsuarioAtualizado.NomeUsuario != null)
            {
                //atribui o valor ao campo existente    
                UsuarioBuscado.NomeUsuario = UsuarioAtualizado.NomeUsuario;
            }

            //atualiza o campo buscado
            ctx.Usuarios.Update(UsuarioBuscado);

            //salva as alterações para serem salvas no banco de dados
            ctx.SaveChanges();
        }

        public Usuario buscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querrySelectAll = "SELECT IdTipoUsuario ,Email, Senha, IdUsuario FROM Usuarios WHERE Email = @email AND Senha = @senha";

                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        Usuario usuariobuscado = new Usuario
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            Email = rdr[1].ToString(),
                            Senha = rdr[2].ToString(),
                            IdUsuario = Convert.ToInt32(rdr[3])
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

        public void Deletar(int id)
        {
            Usuario UsuariosBuscada = ctx.Usuarios.Find(id);

            //remove a classe buscada
            ctx.Usuarios.Remove(UsuariosBuscada);

            //salvas as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public List<Usuario> ListarUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}
