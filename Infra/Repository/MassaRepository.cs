using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;
using System.Collections.Generic;
using Infra.DataSource;
using System.Linq;

namespace Infra.Repository
{
    public class MassaRepository : GenericData<Massa, Int32>, IServiceMassa
    {
        public List<Massa> listPrato(string nome)
        {
            DataContext dc = new DataContext();

            var retorno = dc.Massa.Where(x => x.NomeMassa == nome).ToList();

            return retorno;
        }
    }
}
