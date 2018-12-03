using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public class Fucionario
    {
        public virtual int IdFuncionario { get; set; }
        public virtual PerfilFuncionario Perfil { get; set; }
        public virtual string NomeFuncionario { get; set; }
        public virtual string  Login { get; set; }
        public virtual string  Senha { get; set; }
                                           //public int PerfilFuncionario { get; set; }
        public  enum PerfilFuncionario
        {
            Garcom = 1 ,
            Gerente = 2 
        }
    }
}
