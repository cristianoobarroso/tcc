using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;
using System.Linq;
using System.Collections.Generic;
using Infra.DataSource;

namespace Infra.Repository
{
    public class VinhoRepository : GenericData<Vinho, Int32>, IServiceVinho
    {
        public List<Vinho> listVinho(string nome)
        {
            DataContext dc = new DataContext();

            var retorno = dc.Vinho.Where(x => x.NomeVinho == nome).ToList();

            return retorno;
        }
    }
}
