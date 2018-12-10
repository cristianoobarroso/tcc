using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;
using System.Collections.Generic;
using Infra.DataSource;
using System.Linq;

namespace Infra.Repository
{
    public class CervejaRepository : GenericData<Cerveja, Int32>, IServiceCerveja
    {
        public List<Cerveja> listCerva(string nome)
        {
            DataContext dc = new DataContext();

            var retorno = dc.Cerveja.Where(x => x.NomeCerveja == nome).ToList();

            return retorno;
        }
    }
}
