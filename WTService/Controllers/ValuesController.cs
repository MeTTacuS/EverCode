using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WTService.Models;

namespace WTService.Controllers
{
    public class ValuesController : ApiController
    {

        Person[] tmp = new Person[]
        {
            new Person{id=1, Name= "domas", image = new Bitmap ($"../../Faces/Faces.txt4.bmp", true)},
            new Person{id=2, Name="migle"}
        };

        List<Person> person = tmp.ToList();



        // GET api/values
        public IEnumerable<string> Get()
        {
            List<string> list = new List<string>();
            foreach (Person p in person)
            {
                list.Add(p.Name);
            }
            return list;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return person[id].Name;
        }

        // POST api/values
        public void Post([FromBody]Person p)
        {
            person.Add(new Person { id = p.id, Name = p.Name, image = p.image });
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
