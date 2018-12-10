using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
  public  interface IServiceMassa : IServiceBase<Massa, Int32>
    {
        List<Massa> listPrato(string nome);

    }
}
