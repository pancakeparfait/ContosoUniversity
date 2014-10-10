using System.Configuration;

namespace ContosoUniversity.Web.Infrastructure
{
    public static class ConfigWrapper
    {
        public static string ApplicationTitle
        {
            get { return ConfigurationManager.AppSettings["ApplicationTitle"]; }
        }
    }
}