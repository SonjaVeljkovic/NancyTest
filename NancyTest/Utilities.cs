using System.Configuration;

namespace NancyTest
{
    public static class Utilities
    {
        /// <summary>
        /// Gets connection string from config file.
        /// </summary>
        /// <returns>Connection string</returns>
        public static string GetConnectionStringFromConfiguration()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

    }
}