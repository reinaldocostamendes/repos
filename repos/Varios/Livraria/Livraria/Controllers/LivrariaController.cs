using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    public class LivrariaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Autores()
        {
            return View();
        }
        public IActionResult Categorias()
        {
            return View();
        }
        public IActionResult Livros()
        {
            return View();
        }
    }
}