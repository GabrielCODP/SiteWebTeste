using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSiteWeb.Models
{
    public class ProdutoFormViewModel
    {
        public Produto Produto { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
