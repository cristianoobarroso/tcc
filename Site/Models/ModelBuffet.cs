using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelBuffet
    {
       // public virtual int IdBuffet { get; set; }
        public string TipoBuffet { get; set; }
        public string NomeBuffet { get; set; }
        public int TpProduto { get; set; }
        public string NacionalidadeBuffet { get; set; }
        public decimal ValorBuffet { get; set; }
    }
}