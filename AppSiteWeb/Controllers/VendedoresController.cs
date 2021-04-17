using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppSiteWeb.Services;
using AppSiteWeb.Models;

namespace AppSiteWeb.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;

        public VendedoresController(VendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        public IActionResult Index()
        {
            var list = _vendedorService.FindAll(); //Puxar a lista do VendedorService

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor) //Criar utilizando a ação _service, ela é uma ação de Post
        {
            _vendedorService.Insert(vendedor);

            return RedirectToAction(nameof(Index));
        }
    }
}
