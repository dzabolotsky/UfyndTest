using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufynd.Common.Interfaces
{
    public interface IAppSettingsBase
    {
        string InputFilePath { get; set; }

        string OutputFolderPath { get; set; }
    }
}
