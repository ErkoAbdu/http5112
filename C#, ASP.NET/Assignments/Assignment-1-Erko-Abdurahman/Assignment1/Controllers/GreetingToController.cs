﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{
    public class GreetingToController : ApiController
    {
        /// <summary>
        /// This method returns 2 strings with the inputed number between them when receiving a get request
        /// <example> POST api/greetingto/15</example>
        /// </summary>
        /// <returns>("Greetings to 15 people!</returns>
        public string Get(int id)
        {
            return ("Greetings to " + id + " people!");
        }
    }
}
