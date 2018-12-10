using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Appas
{
    class Person
    {
        public string FName {get; set;}
        public string LName { get; set; }

        public static IList<Lazy<Person>> GetPersonList()
        {
            var person1 = new Lazy<Person>(() => new Person { FName = "Daumantas", LName = "Simkus" });
            var person2 = new Lazy<Person>(() => new Person { FName = "Donas", LName = "Baronas" });
            var person3 = new Lazy<Person>(() => new Person { FName = "Sauna", LName = "Karstoji" });
            var person4 = new Lazy<Person>(() => new Person { FName = "Statys", LName = "Zigulys" });
            var person5 = new Lazy<Person>(() => new Person { FName = "Birute", LName = "Desraine" });
            return new List<Lazy<Person>> { person1, person2, person3, person4, person5 };
        }

        IList<Lazy<Person>> listPerson = Person.GetPersonList();
    }

}