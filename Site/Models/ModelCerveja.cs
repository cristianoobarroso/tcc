using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelCerveja
    {
       // public int IdCerveja { get; set; }
        public string NomeCerveja { get; set; }
        public decimal ValorCerveja { get; set; }
        public int QTDCervejaEstoque { get; set; }
        public string NacionalidadeCerveja { get; set; }
        public int TpProduto { get; set; }
    }
}