using AppSiteWeb.Models;
using AppSiteWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSiteWeb.Controllers
{
    public class TotalDeVendasController : Controller
    {
        private readonly TotalDeVendasServices _totalDeVendasService;
        private readonly VendedorService _vendedorService;
        private readonly ProdutoService _produtoService;

        //public TotalDeVendasController(TotalDeVendasServices totalDeVendasService, VendedorService vendedorService)
        //{
        //    _totalDeVendasService = totalDeVendasService;
        //    _vendedorService = vendedorService;
        //}

        public TotalDeVendasController(TotalDeVendasServices totalDeVendasService, VendedorService vendedorService, ProdutoService produtoService)
        {
            _totalDeVendasService = totalDeVendasService;
            _vendedorService = vendedorService;
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create() 
        {
            var vendedores = await _vendedorService.FindAllCompletoAsync();
            var produto = await _produtoService.FindAllAsync();

            var viewModel = new TotalDeVendasFormViewModel { Vendedores = vendedores, Produtos = produto };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TotalDeVendas vendas)
        {
            if (!ModelState.IsValid)
            {
                var vendedores = await _vendedorService.FindAllCompletoAsync();
                var produto = await _produtoService.FindAllAsync();
                var viewModel = new TotalDeVendasFormViewModel {Vendas=vendas ,Vendedores = vendedores,Produtos=produto };
                return View(viewModel);
            }

            await _totalDeVendasService.InsertAsync(vendas);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) //Se não tem valor minimo
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyy-MM-dd");

            var result = await _totalDeVendasService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) //Se não tem valor minimo
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyy-MM-dd");

            var result = await _totalDeVendasService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
