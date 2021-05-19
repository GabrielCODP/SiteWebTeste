using AppSiteWeb.Data;
using AppSiteWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSiteWeb.Services
{
    public class TotalDeVendasServices
    {
        private readonly AppSiteWebContext _context;

        public TotalDeVendasServices(AppSiteWebContext context)
        {
            _context = context;
        }



        public async Task InsertAsync(TotalDeVendas obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        

   
        public async Task<List<TotalDeVendas>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.TotalDeVendas select obj; //Pegar 

            if (minDate.HasValue) //Informei uma data minima para a busca 
            {
                result = result.Where(x => x.Data >= minDate.Value); //uma retrição
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }

            return await result.Include(x => x.Vendedor).Include(x => x.Vendedor.Departamento).OrderByDescending(x => x.Data).ToListAsync();
        }


        public async Task<List<IGrouping<Departamento,TotalDeVendas>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.TotalDeVendas select obj; //Pegar 

            if (minDate.HasValue) //Informei uma data minima para a busca 
            {
                result = result.Where(x => x.Data >= minDate.Value); //uma retrição
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }

            return await result.Include(x => x.Vendedor).Include(x => x.Vendedor.Departamento).OrderByDescending(x => x.Data).GroupBy(x => x.Vendedor.Departamento).ToListAsync();
        }
    }
}
