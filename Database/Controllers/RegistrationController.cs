using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhosThatDatabase.Models;

namespace WhosThatDatabase.Controllers
{
    public class RegistrationController : ApiController
    {
        [HttpPost]
        [ActionName("registration")]
        public int Register([FromBody]RegistrationModel model)
        {
            if (!ModelState.IsValid)
                return 0;
            else
                return 1;
        }
    }
}
