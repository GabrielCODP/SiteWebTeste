using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSiteWeb.Models
{
    public class TotalDeVendasFormViewModel
    {
        public TotalDeVendas Vendas { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; }
     
    }
}
