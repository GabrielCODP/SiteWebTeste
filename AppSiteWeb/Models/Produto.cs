using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppSiteWeb.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Departamento Departamento { get; set; }

        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }

        public Produto() { }

        public Produto(int id, string nome, double preco, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Departamento = departamento;
        }
    }
}
