using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelMassa
    {
        //  public virtual int IdMassa { get; set; }
       // [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
       // public string TipoMassa { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string NomeMassa { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public int TpProduto { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public decimal Valor { get; set; }

        //[Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        //public int QTDEMassaEstoque { get; set; }
    }
}