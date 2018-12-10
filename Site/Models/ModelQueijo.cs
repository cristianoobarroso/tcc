using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelQueijo
    {
        //public virtual int IdQueijo { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string TipoQueijo { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string NomeQueijo { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string Nacionalidade { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public int TpProduto { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public int QTDQueijoEstoque { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string ValorQueijo { get; set; }
    }
}