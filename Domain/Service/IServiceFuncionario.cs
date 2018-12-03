using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
  public  interface IServiceFuncionario : IServiceBase<Fucionario, Int32>
    {
        bool ProcuraFuncionario(string login, string senha);
       List<Fucionario >DirecionaPorPerfil(string login, string senha);
    }
}
