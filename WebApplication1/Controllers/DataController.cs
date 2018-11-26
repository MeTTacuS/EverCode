using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DataController : ApiController
    {

        Person[] temporary = new Person[]
        {
            new Person { id = 1, name = "Tomato Soup" },
            new Person { id = 2, name = "Yo-yo"},
            new Person { id = 3, name = "Hammer" }
        };

        List<Person> people = new List<Person>(temporary.ToList());

        public IEnumerable<Person> GetAllPeople()
        {
            return people;
        }

        public IHttpActionResult GetPerson(int id)
        {
            var person = people.FirstOrDefault((p) => p.id == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
    }
}
