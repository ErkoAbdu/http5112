using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{
    public class SquareController : ApiController
    {
        /// <summary>
        /// Method returns integer squared when receiving a get request
        ///<example> POST api/question2/5</example>
        /// </summary>
        /// <returns>(id * id)</returns>
        public int Get(int id)
        {
            return (id * id);
        }
    }
}
