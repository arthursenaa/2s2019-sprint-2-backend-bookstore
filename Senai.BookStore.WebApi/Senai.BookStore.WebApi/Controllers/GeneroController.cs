using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domains;
using Senai.BookStore.WebApi.Repositories;

namespace Senai.BookStore.WebApi.Controllers
{
    public class GeneroController : Controller
    {
        GeneroRepository GeneroRepository = new GeneroRepository();

        //Listar --------------------
        [HttpGet]
        public IActionResult ListarAutor()
        {
            return Ok(GeneroRepository.Listar());
        }

        //Cadastrar------------------
        [HttpPost]
        public IActionResult CadastrarAutor(GenerosDomain GeneroDomain)
        {
            GeneroRepository.Cadastrar(GeneroDomain);
            return Ok();
        }
    }
}