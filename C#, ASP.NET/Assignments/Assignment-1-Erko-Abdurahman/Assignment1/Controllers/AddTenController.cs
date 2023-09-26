using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{
    public class AddTenController : ApiController
    {
        /// <summary>
        /// Method returns integer +10 when receiving a get request
        ///<example> POST api/addten/0</example>
        /// </summary>
        /// <returns>(id +10)</returns>
        public int Get(int id)
        {
            return (id + 10);
        }
    }
}
