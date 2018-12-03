using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public class Conta
    {
        public virtual int IdConta { get; set; }
        public virtual int IdCliente { get; set; }

        //public Cliente Cliente { get; set; } // fk

        public virtual decimal ValorConta { get; set; }
        public virtual DateTime DataConta { get; set; }
        public virtual bool StatusConta { get; set; }
        public virtual int NumeroMesa { get; set; }


        public virtual TipoConta TpConta { get; set; }


        public enum TipoConta
        {
            Avulso = 1,
            Regular = 2
        }

    }
}
