﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Abstactions
{
    public interface IDbContext<T> : IDbOperation<T> where T : class
    {
    }
}
