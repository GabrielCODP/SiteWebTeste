using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppSiteWeb.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required] //Necessário
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamnho do nome é entre 3 à 60 caracteres")]
        public string Nome { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [DataType(DataType.EmailAddress)] //Essas semânicas trás funções extra na aplicação
        public string Email { get; set; }


        [Required]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime DataDeNascimento { get; set; }


        [Required]
        [Display(Name = "Salário")]
        [Range(100.0, 50000.00, ErrorMessage = "O salário tem que ser entre {1} até {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Salario { get; set; }

        public Departamento Departamento { get; set; } //O vendedor faz parte de um departamento

        [Display(Name = "Selecionar o Departamento")]
        public int DepartamentoId { get; set; }
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
