using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
  public  interface IServiceItemConta :  IServiceBase<ItemConta, Int32>
    {
        List<ItemConta> ListContasAbertas(int idConta);
        List<ItemConta> ListContasDetalhe(int idConta);
    }
}
