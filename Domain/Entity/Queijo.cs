using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public class Queijo
    {
        public virtual int IdQueijo { get; set; }
        public virtual string TipoQueijo { get; set; }
        public virtual string NomeQueijo { get; set; }
        public virtual int TpProduto { get; set; }
        public virtual int QTDQueijoEstoque { get; set; }
    }
}
