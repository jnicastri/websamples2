using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi2.Controllers
{
    [RoutePrefix("api/v1/person")]
    public class PersonController : ApiController
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Country { get; set; }
        }

        [Route("Person")]
        [HttpGet]
        //[Authorize]
        public Person GetDefaultPerson() => new Person() { FirstName = "Bobby", LastName = "Beens", Country = "Lithuania", Age = 33 };

        [Route("Person")]
        [HttpPut]
        //[Authorize]
        public Person GetDefaultPerson(Person updatedPerson)
        {
            return updatedPerson;
        }
    }
}
