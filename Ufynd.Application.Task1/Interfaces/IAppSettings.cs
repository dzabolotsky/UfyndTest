using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufynd.Task1.Application.Interfaces
{
    public interface IAppSettings
    {
        string InputFilePath { get; set; }

        string OutputFolderPath { get; set; }
    }
}
