using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment_2.Controllers
{
    public class J2Controller : ApiController
    {
        [Route("J2/DiceGame/{dice1}/{dice2}")]
        [HttpGet]
        public int GetTen(int dice1, int dice2)
        {
            int ten = 0;
            for (dice1 = 1; dice1 < 10; dice1++)
            {
                for (dice2 = 1; dice2 < 10; dice2++)
                {
                    if (dice1 + dice2 == 10)
                    {
                        ten ++;
                    }
                }
            }
            /*if (ten == 1)
            {
                return "There is 1 total way to get the sum of 10";
            }
            else
            {
                return "There are " + ten + " total ways to get the sum of 10";
            }*/
            return ten;
            
        }
    }
}
