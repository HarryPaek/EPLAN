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
        private const string defaultCustomConfigFilePath = @"Config\EPLAN_CustomConfig.config";

        private static Configuration _configuration = null;
        private static string customConfigFilePath = string.Empty;

        public static Configuration GetConfiguration(string configPath)
        {
            if(_configuration == null)
            {
                customConfigFilePath = InternalGetCustomConfigFilePath(configPath);

                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap()
                {
                    ExeConfigFilename = customConfigFilePath
                };

                _configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            }
      
            return _configuration;
        }

        public static string GetCustomConfigFilePath()
        {
            return GetCustomConfigFilePath(string.Empty);
        }

        public static string GetCustomConfigFilePath(string configPath)
        {
            if (string.IsNullOrWhiteSpace(customConfigFilePath))
                GetConfiguration(configPath);

            return customConfigFilePath;
        }

        private static string InternalGetCustomConfigFilePath(string configurationFilePath)
        {
            if (string.IsNullOrWhiteSpace(configurationFilePath))
                return GetDefaultCustomConfigFilePath();

            if (Path.IsPathRooted(configurationFilePath))
                return configurationFilePath;

            return Path.Combine(GetCurrentExecutingFolder(), configurationFilePath);
        }

        private static string GetDefaultCustomConfigFilePath()
        {
            return Path.Combine(GetCurrentExecutingFolder(), defaultCustomConfigFilePath);
        }

        public static string GetExecutingAssemblyConfigFileName()
        {
            Assembly exeAssembly = Assembly.GetExecutingAssembly();
            return string.Format("{0}.config", exeAssembly.ManifestModule.Name);
        }

        private static string GetCurrentExecutingFolder()
        {
            Assembly exeAssembly = Assembly.GetExecutingAssembly();

            return Path.GetDirectoryName(exeAssembly.Location);
        }
    }
}
