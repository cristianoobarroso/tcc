using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;
using Infra.DataSource;
using System.Linq;
using System.Collections.Generic;

namespace Infra.Repository
{
    public class ContaRepository : GenericData<Conta, Int32>, IServiceConta
    {
        //public IEnumerable<Conta> RelatorioConta()
        //{
        //    DataContext c = new DataContext();
           
        //       c

        //    return retorno;
        //}

        public Conta UltimaConta()
        {
            DataContext dc = new DataContext();
            var resultado = (from rei in dc.Conta
                             orderby
      rei.DataConta descending
                             select rei).First();

            return resultado;
        }
    }
}
