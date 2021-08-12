﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Common.DTO;

namespace Ufynd.Common.Interfaces
{
    public interface IDataService
    {
        Task<T> GetData<T>(string content) where T : class;
    }
}
