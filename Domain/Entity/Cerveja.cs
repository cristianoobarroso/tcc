using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Domain.Entity
{
  public  class Cerveja
    {
        public virtual int IdCerveja  { get; set; }
        public virtual string NomeCerveja { get; set; }
        public virtual decimal ValorCerveja { get; set; }
        public virtual int QTDCervejaEstoque { get; set; }
        public virtual string NacionalidadeCerveja { get; set; }
        public virtual int TpProduto { get; set; }


        
    }
}
