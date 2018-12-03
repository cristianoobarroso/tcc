using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;

namespace Infra.Repository
{
  public  class QueijoRepository : GenericData<Queijo, Int32>, IServiceQueijo
    {
    }
}
