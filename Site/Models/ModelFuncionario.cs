using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ModelFuncionario
    {
        public  int IdFuncionario { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public  int Perfil { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public  string NomeFuncionario { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public  string Login { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public  string Senha { get; set; }
    }
}