using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelBuffet
    {
        // public virtual int IdBuffet { get; set; }
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string TipoBuffet { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string NomeBuffet { get; set; }
        //public int TpProduto { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string NacionalidadeBuffet { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public decimal ValorBuffet { get; set; }
    }
}