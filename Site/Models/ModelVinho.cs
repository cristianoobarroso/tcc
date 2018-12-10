using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelVinho
    {
        // public virtual int IdVinho { get; set; }
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string TipoVinho { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string NomeVinho { get; set; }
        //public int TpProduto { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public int QTDVinhoEstoque { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string Nacionalidade { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string ValorVinho { get; set; }
    }
}