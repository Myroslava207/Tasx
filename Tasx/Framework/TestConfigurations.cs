using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Tasx.Framework
{
    class TestConfigurations
    {
        public static string Browser;
        public static string Username;
        public static string Password;
        public static string Environment;

        public static TestConfigurations configs;

    
        private static string GetConfigFilePath()
        {
            string executingAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = new DirectoryInfo(executingAssembly).Parent.Parent.Parent.FullName;
            return Path.Combine(path, "MyTestConfigs.xml");
        }

        public static void Configure()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(GetConfigFilePath());

            Browser = xmlDoc.DocumentElement.SelectSingleNode("browser").InnerText;
            Username = xmlDoc.DocumentElement.SelectSingleNode("username").InnerText;
            Password = xmlDoc.DocumentElement.SelectSingleNode("password").InnerText;
            Environment = xmlDoc.DocumentElement.SelectSingleNode("environment").InnerText;
        }
    }
}
