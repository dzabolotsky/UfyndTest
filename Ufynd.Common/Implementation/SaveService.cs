

using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using Ufynd.Common.Interfaces;

namespace Ufynd.Task1.Client.Implementation
{
    public class SaveService : ISaveService
    {
      
        private readonly ILogger<SaveService> _logger;

        public SaveService(ILogger<SaveService> logger)
        {
            
            _logger = logger;
        }
        public Task Save(string content,string outputFolder,string ext)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (!Directory.Exists(outputFolder))
                        Directory.CreateDirectory(outputFolder);
                    var filePath = Path.Combine(outputFolder, $"result_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.{ext}");
                    _logger.LogInformation($"Save parsing result in {filePath}");
                    File.WriteAllText(Path.Combine(outputFolder, $"result_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.{ext}"), content, System.Text.Encoding.UTF8);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                    throw;
                }
            });
            
        }
    }
}
