using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelMassa
    {
      //  public virtual int IdMassa { get; set; }
        public string TipoMassa { get; set; }
        public string NomeMassa { get; set; }
        public int TpProduto { get; set; }
        public int QTDEMassaEstoque { get; set; }
    }
}