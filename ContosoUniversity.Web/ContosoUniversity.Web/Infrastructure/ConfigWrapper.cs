using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

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