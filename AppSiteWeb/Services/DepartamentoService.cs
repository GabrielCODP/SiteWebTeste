using AppSiteWeb.Data;
using AppSiteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AppSiteWeb.Services
{
    public class DepartamentoService
    {
        private readonly AppSiteWebContext _context;

        public DepartamentoService(AppSiteWebContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }

       

    }
}
