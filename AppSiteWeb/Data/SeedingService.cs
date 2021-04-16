using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppSiteWeb.Models;
using AppSiteWeb.Models.Enums;

namespace AppSiteWeb.Data
{
    public class SeedingService
    {
        private AppSiteWebContext _context;
        public SeedingService(AppSiteWebContext context)
        {
            _context = context;
        }


        public void Seed() //Popular a base de dados, quando iniciar o BD
        {
            if (_context.Departamento.Any() || _context.Vendedor.Any() || _context.TotalDeVendas.Any())//Tem algum dado?
            {
                return;
            }


            Departamento d1 = new Departamento(1, "Carros-Novos");
            Departamento d2 = new Departamento(2, "Carros-Usados");
            Departamento d3 = new Departamento(3, "Peças");

            Vendedor s1 = new Vendedor(1, "Sherlock", "Sherlock@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Vendedor s2 = new Vendedor(2, "Dexter", "Dexter@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Vendedor s3 = new Vendedor(3, "Thomas", "Thomas@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Vendedor s4 = new Vendedor(4, "Batman", "Batman@gmail.com", new DateTime(1993, 11, 30), 3000.0, d3);
            Vendedor s5 = new Vendedor(5, "Le", "Le@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
           

            TotalDeVendas r1 = new TotalDeVendas(1, new DateTime(2018, 09, 25), 11000.0, StatusDeVendas.Faturada, s1);
            TotalDeVendas r2 = new TotalDeVendas(2, new DateTime(2018, 09, 25), 11000.0, StatusDeVendas.Pendente, s2);
            TotalDeVendas r3 = new TotalDeVendas(3, new DateTime(2018, 09, 25), 11000.0, StatusDeVendas.Faturada, s3);
            TotalDeVendas r4 = new TotalDeVendas(4, new DateTime(2018, 09, 25), 11000.0, StatusDeVendas.Cancelada, s4);
            TotalDeVendas r5 = new TotalDeVendas(5, new DateTime(2018, 09, 25), 11000.0, StatusDeVendas.Cancelada, s5);

            _context.Departamento.AddRange(d1, d2, d3);
            _context.Vendedor.AddRange(s1, s2, s3, s4, s5);

            _context.TotalDeVendas.AddRange(r1, r2, r3, r4, r5);

            _context.SaveChanges();
        }
    }
}
