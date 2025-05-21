using Microsoft.Extensions.Configuration;
using PersonalLibrary.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.DAL
{
    public class AppSettings : IAppSettings
    {
        public static string ConnectionStringName { get; } = "PersonalLibraryContext";
        public string ConnectionString { get; set; }

        public AppSettings()
        {
            IConfigurationRoot root = GetConfiguration();

            ConnectionString = root.GetConnectionString(ConnectionStringName);
        }

        private IConfigurationRoot GetConfiguration()
        {
            string environment = "Development";

            return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                    .Build();
        }
    }
}