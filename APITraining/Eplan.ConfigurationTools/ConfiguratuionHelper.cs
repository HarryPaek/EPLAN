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
        static string _configFilePath = string.Empty;

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

        public static string GetExecutingAssemblyConfigFileName
        {
            get
            {
                if (string.IsNullOrEmpty(_configFilePath))
                {
                    Assembly exeAssembly = Assembly.GetExecutingAssembly();
                    _configFilePath = string.Format("{0}.config", exeAssembly.ManifestModule.Name);
                }

                return _configFilePath;
            }

            internal set
            {
                _configFilePath = value;
            }
        }
    }
}
