using AppSiteWeb.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppSiteWeb.Models
{
    public class TotalDeVendas
    {
        public int Id { get; set; }

        [Display(Name = "Data da venda")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Total { get; set; }
        public StatusDeVendas Status { get; set; }
        public Vendedor Vendedor { get; set; }

        [Display(Name = "Selecionar o Vendedor")]
        public int VendedorId { get; set; }


        public Produto Produto { get; set; }

        [Display(Name = "Escolha o Produto")]
        public int ProdutoId { get; set; }



        public TotalDeVendas()
        {

        }

        public TotalDeVendas(int id, DateTime data, double amount, StatusDeVendas status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Total = amount;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
