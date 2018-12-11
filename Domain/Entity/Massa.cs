using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
  public  class Massa
    {
        public virtual int IdMassa { get; set; }
        //public virtual string TipoMassa { get; set; }
        public virtual string NomeMassa { get; set; }
        public virtual int TpProduto { get; set; }
        public virtual decimal Valor { get; set; }
                                           // public virtual int QTDEMassaEstoque { get; set; }
    }
}
