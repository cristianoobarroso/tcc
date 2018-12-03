using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public class Buffet
    {
        public virtual int IdBuffet { get; set; }
        public virtual string TipoBuffet { get; set; }
        public virtual string NomeBuffet { get; set; }
        public virtual int TpProduto { get; set; }
        public virtual string NacionalidadeBuffet { get; set; }
        public virtual decimal ValorBuffet { get; set; }
    }
}
