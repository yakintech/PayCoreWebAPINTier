﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.BLL.Services
{
    public interface IUnitOfWork
    {
        ICategoryRepository categoryRepository { get; }
    }
}
