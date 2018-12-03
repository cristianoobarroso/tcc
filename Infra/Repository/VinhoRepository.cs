using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;

namespace Infra.Repository
{
   public class VinhoRepository : GenericData<Vinho , Int32> , IServiceVinho
    {
    }
}
