using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class AutorRepository
    {

        public string StringConexao = "Data Source=localhost;Initial Catalog=T_BookStore;User Id=sa;Pwd=132";

        //Inicio Listar---------------------------------------
        public List<AutoresDomain> Listar()
        {        
            List<AutoresDomain> autores = new List<AutoresDomain>();

            string Query = "select * from Autores";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        AutoresDomain autor = new AutoresDomain
                        {
                            IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                            Nome = sdr["Nome"].ToString(),
                            Email = sdr["Email"].ToString(),
                            Ativo = Convert.ToBoolean(sdr["Ativo"]),
                            DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                        };
                        autores.Add(autor);
                    }
                }
            }
            return autores;
        }
        //Fim Listar-------------------------------------------
        //Inicio Cadastrar-------------------------------------
        public void Cadastrar(AutoresDomain autoresDomain)
        {
            string Query = ("Insert into Autores (Nome,Email,Ativo,DataNascimento) values (@Nome , @Email, @Ativo ,@Data)");


            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Nome", autoresDomain.Nome);
                cmd.Parameters.AddWithValue("@Email", autoresDomain.Email);
                cmd.Parameters.AddWithValue("@Ativo", autoresDomain.Ativo);
                cmd.Parameters.AddWithValue("@Data", autoresDomain.DataNascimento);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //Fim Cadastrar-----------------------------------------
    }
}
