using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppSiteWeb.Models;

namespace AppSiteWeb.Data
{
    public class AppSiteWebContext : DbContext
    {
        public AppSiteWebContext (DbContextOptions<AppSiteWebContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<TotalDeVendas> TotalDeVendas { get; set; }

        public DbSet<Produto> Produto { get; set; }
    }
}
