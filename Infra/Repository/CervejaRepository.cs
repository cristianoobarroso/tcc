using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;

namespace Infra.Repository
{
   public class CervejaRepository  : GenericData<Cerveja, Int32>, IServiceCerveja
    {
    }
}
