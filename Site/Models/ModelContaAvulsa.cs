using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelContaAvulsa
    {

        // entity conta
        public decimal ValorConta { get; set; }
        public bool StatusConta { get; set; }


        // entity item conta

        //  public virtual int IdItem { get; set; }

          public virtual int IdConta { get; set; }
        public virtual int IdCliente { get; set; }

        public int TpProduto { get; set; }
        public int QtdItem { get; set; }
        public string NomeProduto { get; set; }


    }
}