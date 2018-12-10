using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Service
{
  public  interface IServiceBuffet : IServiceBase<Buffet , Int32>
    {
        List<Buffet> listBuffet(string nome);

    }
}
