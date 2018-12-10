using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public class Vendas
    {
        public int IdVenda { get; set; }
       // public int TpProduto { get; set; }
        public decimal ValorVenda { get; set; }
        //public string NomeProduto { get; set; }
        public DateTime DataVenda { get; set; }
    }
}
