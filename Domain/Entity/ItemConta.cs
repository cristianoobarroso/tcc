using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public class ItemConta
    {
        public virtual int IdItem { get; set; }

        public virtual int IdConta { get; set; }
        public Conta Conta { get; set; } // fk

        public virtual int TpProduto { get; set; }
        public virtual int QtdItem { get; set; }
        public virtual string NomeProduto { get; set; }
    }
}
