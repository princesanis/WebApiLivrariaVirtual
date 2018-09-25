using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiLivrariaVirtual.Models;

namespace WebApiLivrariaVirtual.Controllers
{
    [Route("livraria-virtual/[controller]")]
    public class AutoresController : Controller
    {
        private static List<Autor> Autores;
    }
}