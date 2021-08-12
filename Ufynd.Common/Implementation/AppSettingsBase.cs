using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufynd.Common.Implementation
{
    public class AppSettingsBase
    {
        public string InputFilePath { get; set; } = "input";
        public string OutputFolderPath { get; set; } = "output";
    }
}
