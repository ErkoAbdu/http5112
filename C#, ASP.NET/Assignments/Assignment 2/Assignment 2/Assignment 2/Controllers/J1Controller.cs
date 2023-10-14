using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment_2.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        /// input how many items delivered and how many collisions, 50points for each deliver, -10 for each collision, +500 if delivery > collision
        /// J1/6/5
        /// </summary>
        /// <param name="deliver"></param>
        /// <param name="collision"></param>
        /// <returns>750 points</returns>
        //J1 Question Source:https://cemc.math.uwaterloo.ca/contests/computing/past_ccc_contests/2023/ccc/juniorEF.pdf
        [Route("J1/{deliver}/{collision}")]
        [HttpGet]
        public int GetScore(int deliver, int collision)
        {
            int delivered = deliver * 50;
            int collided = collision * -10;
            int points = (delivered + collided);
            if (deliver > collision)
            {
                return points + 500;
            }
            return points;
        }
    }
}
