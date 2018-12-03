using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelQueijo
    {
        //public virtual int IdQueijo { get; set; }
        public  string TipoQueijo { get; set; }
        public  string NomeQueijo { get; set; }
        public  int TpProduto { get; set; }
        public  int QTDQueijoEstoque { get; set; }
    }
}