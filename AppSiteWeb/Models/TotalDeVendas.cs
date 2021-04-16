using AppSiteWeb.Models.Enums;
using System;

namespace AppSiteWeb.Models
{
    public class TotalDeVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set; }
        public StatusDeVendas Status { get; set; }
        public Vendedor Vendedor { get; set; } 

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
