using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Task1.Application.Interfaces;

namespace Ufynd.Task1.Application.Implementation
{
	public class AppSettings:IAppSettings 
	{
		public string InputFilePath { get; set; } = "input";
		public string OutputFolderPath { get; set; } = "output";
    }
}
