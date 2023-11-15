﻿using PayCore.DAL.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.BLL.Services
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
