using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domains;
using Senai.BookStore.WebApi.Repositories;

namespace Senai.BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AutorController : Controller
    {

        AutorRepository AutorRepository = new AutorRepository();

        //Listar --------------------
        [HttpGet]
        public IActionResult ListarAutor()
        {
            return Ok(AutorRepository.Listar());
        }

        //Cadastrar------------------
        [HttpPost]
        public IActionResult CadastrarAutor(AutoresDomain autorDomain)
        {
            AutorRepository.Cadastrar(autorDomain);
            return Ok();
        }
    }
}