using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSiteWeb.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>(); //Ele tem vários vendedores, dentro de um departamento.
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public Departamento()
        {
        }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public void AddProduto(Produto produto)
        {
            Produtos.Add(produto);
        }

        public double TotalDeVendasDepartamento(DateTime inicio, DateTime final)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalDeVendas(inicio, final));//Somar o total de vendas dessa lista de vendedores.
        }

    }
}
