using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;
namespace Infra.Repository
{
   public class MassaRepository : GenericData<Massa, Int32>, IServiceMassa
    {
    }
}
