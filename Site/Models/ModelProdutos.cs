using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelProdutos
    {
        //cerveja
        public string NomeCerveja { get; set; }
        public decimal ValorCerveja { get; set; }
        public int QtdsolicitadaCerveja { get; set; }
        public string NacionalidadeCerveja { get; set; }
        //  public int TpProduto { get; set; }

        public int IdConta { get; set; }

        //massa
        public string TipoMassa { get; set; }
        public string NomeMassa { get; set; }
       // public int TpProduto { get; set; }
        public int QTDEMassaEstoque { get; set; }

        //queijo
        public string TipoQueijo { get; set; }
        public string NomeQueijo { get; set; }
        public int TpProduto { get; set; }
        public int QTDQueijoEstoque { get; set; }

        //vinho
        // public virtual int IdVinho { get; set; }
        public string TipoVinho { get; set; }
        public string NomeVinho { get; set; }
        //public int TpProduto { get; set; }
        public int QTDVinhoEstoque { get; set; }


    }
}