using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication12.Controllers
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        private static string[] _firstNames =
        {
            "Avrumi", "Chaim", "Yechiel", "Tzvi", "Suchi", "Shea", "Elkanah",
            "Nechemia", "Yudi", "Sholom"
        };

        private static string[] _lastNames =
        {
            "Friedman", "Friedman", "Cohen", "Shoop", "Waldman", "Weidberg", "Werther",
            "Schorr", "Goldgrab", "Rechnitz"
        };

        private static Random _rnd = new Random();
        public static IEnumerable<Person> GetRandomPeople(int amount)
        {
            return Enumerable.Range(1, amount).Select(_ => new Person
            {
                FirstName = _firstNames[_rnd.Next(_firstNames.Length)],
                LastName = _lastNames[_rnd.Next(_lastNames.Length)],
                Age = _rnd.Next(20, 65)
            });
        }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPeople(int peopleAmount)
        {
            IEnumerable<Person> ppl = Person.GetRandomPeople(peopleAmount);
            return Json(ppl, JsonRequestBehavior.AllowGet);
        }

    }
}
