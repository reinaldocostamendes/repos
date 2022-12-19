using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Autores()
        {
            return View();
        }
        public IActionResult InsertAutor()
        {
            return View();
        }
        public IActionResult EditAutor()
        {
            return View();
        }
        public IActionResult Categorias()
        {
            return View();
        }
        public IActionResult InsertCategoria()
        {
            return View();
        }
        public IActionResult EditCategoria()
        {
            return View();
        }
        public IActionResult Clientes()
        {
            return View();
        }
        public IActionResult InsertCliente()
        {
            return View();
        }
        public IActionResult EditCliente()
        {
            return View();
        }
        public IActionResult Encomendas()
        {
            return View();
        }
        public IActionResult InsertEncomenda()
        {
            return View();
        }
        public IActionResult EditEncomenda()
        {
            return View();
        }
        public IActionResult Livros()
        {
            return View();
        }
        public IActionResult InsertLivro()
        {
            return View();
        }
        public IActionResult EditLivro()
        {
            return View();
        }
    }
}