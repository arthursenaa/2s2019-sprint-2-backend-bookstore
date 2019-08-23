using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class LivroRepository
    {
        public string StringConexao = "Data Source=localhost;Initial Catalog=T_BookStore;User Id=sa;Pwd=132";



        public List<LivrosDomain> Listar()
        {
            List<LivrosDomain> Livros = new List<LivrosDomain>();

            string Query = "select Livros.Titulo , Autores.Nome As Autor , Generos.Nome as Genero from Livros inner join Autores on Livros.IdAutor = Autores.IdAutor inner join Generos on Livros.IdGenero = Generos.IdGenero ";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        LivrosDomain Livro = new LivrosDomain
                        {
                            IdLivros = Convert.ToInt32(sdr["IdLivros"]),
                            Titulo = sdr["Titulo"].ToString(),
                            Autor = new AutoresDomain
                            {
                                IdAutor = Convert.ToInt32(sdr[2]),
                                Nome = sdr[3].ToString(),
                                Email = sdr["Email"].ToString(),
                                Ativo = Convert.ToBoolean(sdr["Ativo"]),
                                DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                            },
                            Genero = new GenerosDomain
                            {
                                IdGenero = Convert.ToInt32(sdr[2]),
                                Nome = sdr[3].ToString()
                            }
                        };
                        Livros.Add(Livro);
                    }
                }
            }
            return Livros;
        }

    }
}
