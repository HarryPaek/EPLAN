using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Eplan.ConfigurationTools
{
    public class ConfiguratuionHelper
    {
        public static Configuration GetConfiguration(string configPath)
        {
            if (string.IsNullOrWhiteSpace(configPath) || !File.Exists(configPath))
                configPath = DefaultCustomConfigFilePath;

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap()
            {
                ExeConfigFilename = configPath
            };
      
            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }

        public static string DefaultCustomConfigFilePath
        {
            get { return @".\Config\EPLAN_CustomConfig.config"; }
        }

        public static string GetExecutingAssemblyConfigFileName()
        {
            Assembly exeAssembly = Assembly.GetExecutingAssembly();
            return string.Format("{0}.config", exeAssembly.ManifestModule.Name);
        }
    }
}
