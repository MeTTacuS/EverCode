using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appas

{
   class AppSettings
   {
      
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

        public static string Uri { get
            {

                return "https://whosthatapi.azurewebsites.net/";
            } }
    }
}
