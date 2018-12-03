﻿using System;
using Infra.Generics;
using Domain.Entity;
using Domain.Service;

namespace Infra.Repository
{
  public  class VendasRepository : GenericData<Vendas, Int32>, IServiceVendas
    {
    }
}
