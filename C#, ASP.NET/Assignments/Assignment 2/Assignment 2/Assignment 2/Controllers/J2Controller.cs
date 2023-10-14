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
        /// <summary>
        /// input number of sides on dice in dice1 and dice2. If d1 is <= dice1 and 2 increment by 1. If d1 + d2 = 10 increment by 1.
        /// J2/DiceGame/5/5
        /// </summary>
        /// <param name="dice1"></param>
        /// <param name="dice2"></param>
        /// <returns>"There is 1 total way to get to the sum of 10"</returns>
        [Route("api/J2/DiceGame/{dice1}/{dice2}")]
        [HttpGet]
        public string GetTen(int dice1, int dice2)
        {
            int count = 0;
            string message1 = "There is 1 total way to get to the sum of 10";

            for (int d1 = 1; d1 <= dice1; d1++)
            {
                for (int d2 = 1; d2 <= dice2; d2++)
                {
                    if (d1 + d2 == 10)
                    {
                        count++;
                    }                        
                }
            }
             if (count == 1)
             {
                 return message1;
             }
             else
             {
                string message2 = "There are ";
                string message3 = " total ways to get the sum of 10";
                string message4 = message2 + count.ToString() + message3;
                return message4;
             }
        }

    }
}
