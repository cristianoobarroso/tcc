﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
  public  interface IServiceQueijo : IServiceBase<Queijo, Int32>
    {
        List<Queijo> listQueijo(string nome);

    }
}
