using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace FaunadbShopApplication.Test
{
    public class TestBase
    {
        protected readonly IConfigurationRoot Configuration;
        public TestBase()
        {
            var settingsFileFolder = ApplicationSettingsDirectory();
            Configuration = new ConfigurationBuilder()
                            .SetBasePath(settingsFileFolder)
                            .AddJsonFile("appsettings.json").Build();

        }

        private  string ApplicationSettingsDirectory()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Func<string, int, string> getParentFolder = (basePath, upValue) =>
                {
                    for (int i = 0; i < upValue; i++)
                    {
                        basePath = Directory.GetParent(basePath).FullName;
                    }
                    return basePath;
                };
            var appRoot = Path.Combine(getParentFolder(Path.GetDirectoryName(location), 4), "FaunadbShopApplication");

            return appRoot;
        }
    }
}
