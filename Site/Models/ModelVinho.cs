using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelVinho
    {
        // public virtual int IdVinho { get; set; }
        public string TipoVinho { get; set; }
        public string NomeVinho { get; set; }
        //public int TpProduto { get; set; }
        public int QTDVinhoEstoque { get; set; }
    }
}