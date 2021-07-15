using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Data.DataContext
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            IConfigurationRoot root = configBuilder.Build();
            IConfigurationSection appSetting = root.GetSection("ConnectionStrings:DevConnection");
            SqlConnectionString = appSetting.Value;
        }

        public string SqlConnectionString { get; set; }
    }
}
