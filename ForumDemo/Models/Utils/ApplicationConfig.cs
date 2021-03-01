using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ForumDemo.Models.Utils
{
    public class ApplicationConfig
    {
        static ApplicationConfig instance;
        public static ApplicationConfig Instance => instance ?? (instance = new ApplicationConfig());

        public string DefaultEmail => ConfigurationManager.AppSettings["defaultEmail"];
        public string DefaultEmailPassword => ConfigurationManager.AppSettings["defaultEmailPassword"];

        private ApplicationConfig()
        {
            
        }
    }
}