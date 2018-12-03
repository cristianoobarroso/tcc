using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public class Cliente
    {
        public virtual int IdCliente { get; set; }
        public virtual string NomeCliente { get; set; }
        public virtual string CPFCliente { get; set; }
        public virtual string EmailCliente { get; set; }
        public virtual TipoCliente TpCliente { get; set; }
        public virtual DateTime DtaCadastro { get; set; }
        public enum TipoCliente
        {
            Avulso = 1,
            Regular = 2
        }

    }
}
