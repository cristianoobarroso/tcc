using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;


namespace Infra.Repository
{
   public class BuffetRepository : GenericData<Buffet, Int32>, IServiceBuffet
    {
    }
}
