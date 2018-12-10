using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
   public interface IServiceVinho : IServiceBase<Vinho, Int32>
    {
        List<Vinho> listVinho(string nome);

    }
}
