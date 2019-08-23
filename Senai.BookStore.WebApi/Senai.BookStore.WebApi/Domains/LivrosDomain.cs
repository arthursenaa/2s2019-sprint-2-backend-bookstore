using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Domains
{
    public class LivrosDomain
    {
        public int IdLivros { get; set; }
        public string Titulo { get; set; }
        public int IdAutor { get; set; }
        public AutoresDomain Autor { get; set; }
        public int IdGenero {get;set;}
        public GenerosDomain Genero { get; set; }
    }
}
