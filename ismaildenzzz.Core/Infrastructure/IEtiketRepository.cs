﻿using ismaildenzzz.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ismaildenzzz.Core.Infrastructure
{
    public interface IEtiketRepository : IRepository<Etiket>
    {
        int CountByObject(Etiket item);
    }
}
