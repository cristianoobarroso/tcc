using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;
using System.Collections.Generic;
using Infra.DataSource;
using System.Linq;

namespace Infra.Repository
{
    public class ItemRepository : GenericData<ItemConta, Int32>, IServiceItemConta
    {
        public List<ItemConta> ListContasAbertas(int idConta)
        {
            DataContext dc = new DataContext();
            var result = dc.ItemConta.Where(x => x.IdConta == idConta).ToList();
            return result;
        }

        public List<ItemConta> ListContasDetalhe(int idConta)
        {
            throw new NotImplementedException();
        }
    }
}
