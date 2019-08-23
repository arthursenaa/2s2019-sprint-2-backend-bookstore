using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class GeneroRepository
    {

        public string StringConexao = "Data Source=localhost;Initial Catalog=T_BookStore;User Id=sa;Pwd=132";


        //Inicio Listar----------------------------------------
        public List<GenerosDomain> Listar()
        {
            List<GenerosDomain> generos = new List<GenerosDomain>();

            string Query = "select * from Generos";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GenerosDomain genero = new GenerosDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdAutor"]),
                            Nome = sdr["Nome"].ToString(),
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }
        //Fim Listar-------------------------------------------
        //Inicio Cadastrar-------------------------------------
        public void Cadastrar(GenerosDomain generosDomain)
        {
            string Query = ("Insert into Generos (Nome) values (@Nome)");


            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Nome", generosDomain.Nome);
               
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //Fim Cadastrar----------------------------------------
    }
}
