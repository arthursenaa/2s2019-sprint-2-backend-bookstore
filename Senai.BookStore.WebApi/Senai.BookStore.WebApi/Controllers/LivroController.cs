using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Repositories;

namespace Senai.BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LivroController : Controller
    {


        LivroRepository LivroRepository = new LivroRepository();


        [HttpGet]
        public IActionResult ListarLivro()
        {
            return Ok(LivroRepository.Listar());
        }
    }
}