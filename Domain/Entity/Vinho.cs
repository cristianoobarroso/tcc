using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public class Vinho
    {
        public virtual int IdVinho { get; set; }
        public virtual string TipoVinho { get; set; }
        public virtual string NomeVinho { get; set; }
        public virtual int TpProduto { get; set; }
        public virtual int QTDVinhoEstoque { get; set; }
        public virtual string Nacionalidade { get; set; }
        public virtual decimal ValorVinho { get; set; }
    }
}
