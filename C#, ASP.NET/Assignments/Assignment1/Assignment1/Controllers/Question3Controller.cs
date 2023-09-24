using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{
    public class Question3Controller : ApiController
    {
        /// <summary>
        /// This method returns a string when receiving a get request
        /// <example> POST api/question3</example>
        /// </summary>
        /// <returns> "Hello World!" </returns>
        public string Get()
        {
            return "Hello World!";
        }
    }
}
