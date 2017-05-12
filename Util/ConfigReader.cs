using System.Configuration;
using Util.Interfaces;

namespace Util
{
    public class ConfigReader : IConfigReader
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["eLog2"].ConnectionString;
        }
    }
}