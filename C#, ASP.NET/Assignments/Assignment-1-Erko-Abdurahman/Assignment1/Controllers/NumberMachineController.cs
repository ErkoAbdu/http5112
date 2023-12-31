﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{
    public class NumberMachineController : ApiController
    {
        /// <summary>
        /// Method returns double after 4 math operations when receiving a get request
        /// <example> POST api/numbermachine/15/</example>
        /// </summary>
        /// <returns> ((15/5) * 20 + 4 - 9) = 55 </returns>
        public double Get (double id)
        {
            return ((id / 5) * 20 + 4 - 9);
        }
    }
}
