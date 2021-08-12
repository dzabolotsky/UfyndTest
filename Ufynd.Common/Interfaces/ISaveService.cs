using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufynd.Common.Interfaces
{
    public interface ISaveService
    {
        Task Save(string content, string outputFolder, string ext);
    }
}
