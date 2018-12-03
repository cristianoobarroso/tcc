using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;
using Infra.DataSource;
using System.Linq;
using System.Collections.Generic;

namespace Infra.Repository
{
    public class FuncionarioRepository : GenericData<Fucionario, Int32>, IServiceFuncionario
    {


        public bool ProcuraFuncionario(string login, string senha)
        {
            DataContext bd = new DataContext();
            var func = false;
            var retorno = bd.Fucionario.Where(f => f.Login == login && f.Senha == senha).ToList();

            if (retorno.Count == 0)
                func = false;
            else
                func = true;


            return func;
        }

      public  List<Fucionario> DirecionaPorPerfil(string login, string senha)
        {
            using (DataContext c = new DataContext())
            {
                var retorno = (from f in c.Fucionario where f.Login == login && f.Senha == senha select f).ToList();
                return retorno;
            }
        }
    }
}
