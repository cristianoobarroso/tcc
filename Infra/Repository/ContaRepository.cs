using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;
using Infra.DataSource;
using System.Linq;


namespace Infra.Repository
{
    public class ContaRepository : GenericData<Conta, Int32>, IServiceConta
    {
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
