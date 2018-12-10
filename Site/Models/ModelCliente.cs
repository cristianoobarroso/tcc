using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelCliente
    {
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string CPFCliente { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string EmailCliente { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public int IdCliente { get; set; }

    }
}