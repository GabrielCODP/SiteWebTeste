using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSiteWeb.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public double Salario { get; set; }
        public Departamento Departamento { get; set; } //O vendedor faz parte de um departamento
        public ICollection<TotalDeVendas> Vendas { get; set; } = new List<TotalDeVendas>(); //Cada vendedor tem suas vendas, registrada.

        public Vendedor() { }

        public Vendedor(int id, string nome, string email, DateTime dataDeNascimento, double salario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataDeNascimento = dataDeNascimento;
            Salario = salario;
            Departamento = departamento;
        }



        public void AddVendas(TotalDeVendas vendas)
        {
            Vendas.Add(vendas);
        }

        public void RemoveVendas(TotalDeVendas vendas)
        {
            Vendas.Remove(vendas);
        }

        public double TotalDeVendas(DateTime inicio, DateTime final)
        {
            return Vendas.Where(ven => ven.Data >= inicio && ven.Data <= final).Sum(ven => ven.Total);
        }
    }
}
