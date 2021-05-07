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

        public TotalDeVendasController(TotalDeVendasServices totalDeVendasService)
        {
            _totalDeVendasService = totalDeVendasService;
        }

        public IActionResult Index()
        {
            return View();
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
