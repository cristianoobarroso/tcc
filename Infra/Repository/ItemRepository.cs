using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;
namespace Infra.Repository
{
   public class ItemRepository :  GenericData<ItemConta, Int32>, IServiceItemConta
    {
    }
}
