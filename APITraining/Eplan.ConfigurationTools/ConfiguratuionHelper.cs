using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eplan.ConfigurationTools
{
    public class ConfiguratuionHelper
    {
        public const string DefaultConfigFilePath = @".\Config\EPLAN_CustomConfig.config";

        public static Configuration GetConfiguration(string configPath)
        {
            if (string.IsNullOrWhiteSpace(configPath) || !File.Exists(configPath))
                configPath = DefaultConfigFilePath;

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap()
            {
                ExeConfigFilename = configPath
            };
      
            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }
    }
}
