using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;
using Infra.DataSource;
using System.Linq;
using System.Collections.Generic;

namespace Infra.Repository
{
    public class ClienteRepository : GenericData<Cliente, Int32>, IServiceCliente
    {
       
      public  List<Cliente> ClientesFidelizados()
        {
            DataContext dc = new DataContext();
            var resultado = (from p in dc.Cliente orderby p.NomeCliente where p.TpCliente == Cliente.TipoCliente.Regular select p ).ToList(); 

            return resultado;
        }
    }

}
