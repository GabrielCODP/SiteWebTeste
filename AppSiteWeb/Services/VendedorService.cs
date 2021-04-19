using AppSiteWeb.Data;
using AppSiteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSiteWeb.Services
{
    public class VendedorService
    {
        private readonly AppSiteWebContext _context;

        public VendedorService(AppSiteWebContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList(); //Acessar os dados da tabela de vendedores.
        }

        public void Insert(Vendedor obj) //Inserir um novo vendedor
        {
            obj.Departamento = _context.Departamento.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
