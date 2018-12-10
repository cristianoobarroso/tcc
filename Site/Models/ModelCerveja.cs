using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelCerveja
    {
        // public int IdCerveja { get; set; }
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{3,50}$", ErrorMessage = "Inválido")]
        public string NomeCerveja { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public decimal ValorCerveja { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        [RegularExpression("^[0-9]+$", ErrorMessage ="Inválido")]
        public int QTDCervejaEstoque { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{1,50}$", ErrorMessage = "*")]
        public string NacionalidadeCerveja { get; set; }


        public int TpProduto { get; set; }
    }
}