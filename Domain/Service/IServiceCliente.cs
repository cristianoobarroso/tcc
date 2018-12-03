﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
   public interface IServiceCliente : IServiceBase<Cliente, Int32>
    {
        List<Cliente> ClientesFidelizados();
    }
}
