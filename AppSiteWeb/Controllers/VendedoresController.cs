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
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var list = _vendedorService.FindAll(); //Puxar a lista do VendedorService

            return View(list);
        }

        public IActionResult Create() //abrir o formulario com os departamentos.
        {
            var departamentos = _departamentoService.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
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
