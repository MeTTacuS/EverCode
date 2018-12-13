using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager
{
   class AppSettings
   {
      public static string Endpoint
      {
         get
         {
            return ConfigurationManager.AppSettings["Endpoint"];
         }
      }

      public static string Key1
      {
         get
         {
            return ConfigurationManager.AppSettings["Key1"];
         }
      }

      public static string Key2
      {
         get
         {
            return ConfigurationManager.AppSettings["Key2"];
         }
      }

      public static string PersonGroupBaseFolder
      {
         get
         {
            return ConfigurationManager.AppSettings["PersonGroupBaseFolder"];
         }
      }
        public static string GroupId
        {
            get
            {
                return "1";
            }
        }
        public static string GroupName
        {
            get
            {
                return "group";
            }
        }
        public static string GroupDesc
        {
            get
            {
                return "desc";
            }
        }
    }
}
