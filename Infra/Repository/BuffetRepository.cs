using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;
using System.Linq;
using Infra.DataSource;
using System.Collections.Generic;

namespace Infra.Repository
{
    public class BuffetRepository : GenericData<Buffet, Int32>, IServiceBuffet
    {
        public List<Buffet> listBuffet(string nome)
        {
            DataContext dc = new DataContext();

            var retorno = dc.Buffet.Where(x => x.NomeBuffet == nome).ToList();

            return retorno;
        }
    }
}
