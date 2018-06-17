using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swagger.Net.Annotations;

namespace WebApi2.Controllers
{
    [RoutePrefix("api/v1/person")]
    public class PersonController : ApiController
    {
        /// <summary>
        /// Represents a person entity
        /// </summary>
        public class Person
        {
            /// <summary>
            /// The persons first name
            /// </summary>
            public string FirstName { get; set; }
            /// <summary>
            /// THe person surname
            /// </summary>
            public string LastName { get; set; }
            /// <summary>
            /// Persons age in full years
            /// </summary>
            public int Age { get; set; }
            /// <summary>
            /// The persons country of origin
            /// </summary>
            public string Country { get; set; }
        }

        [Route("Person")]
        [HttpGet]
        [Authorize]
        public Person GetDefaultPerson() => new Person() { FirstName = "Bobby", LastName = "Beens", Country = "Lithuania", Age = 33 };

        [Route("Person")]
        [HttpPut]
        [Authorize]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Description = "A non-authenicated WIndows User")]
        [SwaggerResponse(HttpStatusCode.Accepted, Description ="Another descritpion")]
        [SwaggerResponse(HttpStatusCode.OK, Type=typeof(Person), Description ="The resource itself")]
        public Person GetDefaultPerson(Person updatedPerson)
        {
            return updatedPerson;
        }
    }
}
