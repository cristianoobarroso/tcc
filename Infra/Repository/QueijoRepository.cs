using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;
using System.Collections.Generic;
using Infra.DataSource;
using System.Linq;

namespace Infra.Repository
{
    public class QueijoRepository : GenericData<Queijo, Int32>, IServiceQueijo
    {
        public List<Queijo> listQueijo(string nome)
        {
            DataContext dc = new DataContext();

            var retorno = dc.Queijo.Where(x => x.NomeQueijo == nome).ToList();

            return retorno;
        }
    }
}
